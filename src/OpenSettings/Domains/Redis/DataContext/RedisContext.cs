using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Domains.Redis.DataContext
{
    public abstract class RedisContext : IAsyncDisposable, IDisposable
    {
        private long _lastReconnectTicks = DateTimeOffset.MinValue.UtcTicks;
        private DateTimeOffset _firstErrorTime = DateTimeOffset.MinValue;
        private DateTimeOffset _previousErrorTime = DateTimeOffset.MinValue;
        private bool _disposed;
        private string[] _endpoints;
        private readonly ConfigurationOptions _configurationOptions;
        private readonly Lazy<ConcurrentDictionary<string, ISubscriber>> _nameToSubscriber = new Lazy<ConcurrentDictionary<string, ISubscriber>>();
        private readonly Lazy<ConcurrentDictionary<string, IServer>> _endpointToServer = new Lazy<ConcurrentDictionary<string, IServer>>();

        private IConnectionMultiplexer _connectionMultiplexer;

        private Lazy<Func<ConfigurationOptions, Task<ConnectionMultiplexer>>> _asyncConnection = AsyncConnection();

        private Lazy<Func<ConfigurationOptions, ConnectionMultiplexer>> _normalConnection = NormalConnection();

        private readonly TimeSpan _reconnectMinInterval;
        private readonly TimeSpan _reconnectErrorThreshold;
        private readonly TimeSpan _restartConnectionTimeout;
        private readonly int? _retryMaxAttempts;
        private readonly SemaphoreSlim _reconnectSemaphore = new SemaphoreSlim(initialCount: 1, maxCount: 1);

        protected RedisContext(ConfigurationOptions opts, RedisContextOptions redisContextOptions = null)
        {
            _configurationOptions = opts ?? throw new ArgumentNullException(nameof(opts));
            redisContextOptions = redisContextOptions ?? new RedisContextOptions();
            _configurationOptions.AbortOnConnectFail = false;
            _reconnectMinInterval = redisContextOptions.ReconnectMinInterval;
            _reconnectErrorThreshold = redisContextOptions.ReconnectErrorThreshold;
            _restartConnectionTimeout = redisContextOptions.RestartConnectionTimeout;
            _retryMaxAttempts = redisContextOptions.RetryMaxAttempts;
        }

        private async Task<IConnectionMultiplexer> GetConnectionAsync() => _connectionMultiplexer ?? (_normalConnection.IsValueCreated ? _normalConnection.Value(_configurationOptions) : await _asyncConnection.Value(_configurationOptions).ConfigureAwait(false));
        
        public async Task ConnectAsync() => Connection = await GetConnectionAsync().ConfigureAwait(false);
        
        private IConnectionMultiplexer GetConnection() => _connectionMultiplexer ?? (_asyncConnection.IsValueCreated ? _asyncConnection.Value(_configurationOptions).Result : _normalConnection.Value(_configurationOptions));
        
        public void Connect() => Connection = GetConnection();

        public IConnectionMultiplexer Connection
        {
            get => GetConnection();
            private set => _connectionMultiplexer = value;
        }

        public IEnumerable<string> Endpoints => _endpoints ?? (_endpoints = _configurationOptions.EndPoints.Select(e => e.ToString()).ToArray());

        public ISubscriber GetSubscriber(string name)
        {
            if (!_nameToSubscriber.Value.TryGetValue(name, out var subscriber))
            {
                subscriber = Connection.GetSubscriber(); // There is no cache while using Connection.GetSubscriber() | GetDatabase method has Cache inside
                _nameToSubscriber.Value.TryAdd(name, subscriber);
            }

            return subscriber;
        }

        /// <summary>
        /// If endpoint not exists returns null
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IServer GetServer(string endpoint)
        {
            if (!_endpointToServer.Value.TryGetValue(endpoint, out var server))
            {
                try
                {
                    server = Connection.GetServer(endpoint);
                    _endpointToServer.Value.TryAdd(endpoint, server);
                }
                catch (NotSupportedException)
                {
                    return null;
                }
            }

            return server;
        }

        public async Task<T> SafetyExecuteAsync<T>(Func<IConnectionMultiplexer, Task<T>> func)
        {
            var reconnectRetry = 0;

            while (true)
            {
                try
                {
                    return await func(Connection);
                }
                catch (Exception ex) when (ex is RedisConnectionException || ex is SocketException || ex is ObjectDisposedException)
                {
                    reconnectRetry++;
                    if (reconnectRetry > _retryMaxAttempts)
                    {
                        throw;
                    }

                    try
                    {
                        await ReconnectAsync().ConfigureAwait(false);
                    }
                    catch (ObjectDisposedException) { }

                    return await func(Connection);
                }
            }
        }

        public T SafetyExecute<T>(Func<IConnectionMultiplexer, T> func)
        {
            var reconnectRetry = 0;

            while (true)
            {
                try
                {
                    return func(Connection);
                }
                catch (Exception ex) when (ex is RedisConnectionException || ex is SocketException || ex is ObjectDisposedException)
                {
                    reconnectRetry++;

                    if (reconnectRetry > _retryMaxAttempts)
                    {
                        throw;
                    }

                    try
                    {
                        Reconnect();
                    }
                    catch (ObjectDisposedException) { }

                    return func(Connection);
                }
            }
        }

        private async Task ReconnectAsync()
        {
            var previousTicks = Interlocked.Read(ref _lastReconnectTicks);
            var previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
            var elapsedSinceLastReconnect = DateTimeOffset.UtcNow - previousReconnectTime;

            if (elapsedSinceLastReconnect < _reconnectMinInterval)
            {
                return;
            }

            try
            {
                await _reconnectSemaphore.WaitAsync(_restartConnectionTimeout).ConfigureAwait(false);
            }
            catch
            {
                return;
            }

            try
            {
                var utcNow = DateTimeOffset.UtcNow;
                elapsedSinceLastReconnect = utcNow - previousReconnectTime;

                if (_firstErrorTime == DateTimeOffset.MinValue)
                {
                    _firstErrorTime = utcNow;
                    _previousErrorTime = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < _reconnectMinInterval)
                {
                    return;
                }

                var elapsedSinceFirstError = utcNow - _firstErrorTime;
                var elapsedSinceMostRecentError = utcNow - _previousErrorTime;

                var shouldReconnect =
                    elapsedSinceFirstError >= _reconnectErrorThreshold
                    && elapsedSinceMostRecentError <= _reconnectErrorThreshold;

                _previousErrorTime = utcNow;

                if (!shouldReconnect)
                {
                    return;
                }

                _firstErrorTime = DateTimeOffset.MinValue;
                _previousErrorTime = DateTimeOffset.MinValue;

                if (_normalConnection != null)
                {
                    try
                    {
                        await Connection.CloseAsync().ConfigureAwait(false);
                    }
                    catch { /* */ }
                }

                Interlocked.Exchange(ref _connectionMultiplexer, null);
                Interlocked.Exchange(ref _asyncConnection, AsyncConnection());
                Interlocked.Exchange(ref _normalConnection, NormalConnection());

                var newConnection = await _asyncConnection.Value(_configurationOptions).ConfigureAwait(false);

                Interlocked.Exchange(ref _connectionMultiplexer, newConnection);
                Interlocked.Exchange(ref _lastReconnectTicks, utcNow.UtcTicks);
            }
            finally
            {
                _reconnectSemaphore.Release();
            }
        }

        private void Reconnect()
        {
            var previousTicks = Interlocked.Read(ref _lastReconnectTicks);
            var previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
            var elapsedSinceLastReconnect = DateTimeOffset.UtcNow - previousReconnectTime;

            if (elapsedSinceLastReconnect < _reconnectMinInterval)
                return;

            try
            {
                _reconnectSemaphore.Wait(_restartConnectionTimeout);
            }
            catch
            {
                return;
            }

            try
            {
                var utcNow = DateTimeOffset.UtcNow;
                elapsedSinceLastReconnect = utcNow - previousReconnectTime;

                if (_firstErrorTime == DateTimeOffset.MinValue)
                {
                    _firstErrorTime = utcNow;
                    _previousErrorTime = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < _reconnectMinInterval)
                    return;

                var elapsedSinceFirstError = utcNow - _firstErrorTime;
                var elapsedSinceMostRecentError = utcNow - _previousErrorTime;

                var shouldReconnect =
                    elapsedSinceFirstError >= _reconnectErrorThreshold
                    && elapsedSinceMostRecentError <= _reconnectErrorThreshold;

                _previousErrorTime = utcNow;

                if (!shouldReconnect)
                    return;

                _firstErrorTime = DateTimeOffset.MinValue;
                _previousErrorTime = DateTimeOffset.MinValue;

                if (_normalConnection != null)
                {
                    try
                    {
                        Connection.Close();
                    }
                    catch { /* */ }
                }

                Interlocked.Exchange(ref _connectionMultiplexer, null);
                Interlocked.Exchange(ref _asyncConnection, AsyncConnection());
                Interlocked.Exchange(ref _normalConnection, NormalConnection());

                var newConnection = _normalConnection.Value(_configurationOptions);

                Interlocked.Exchange(ref _connectionMultiplexer, newConnection);
                Interlocked.Exchange(ref _lastReconnectTicks, utcNow.UtcTicks);
            }
            finally
            {
                _reconnectSemaphore.Release();
            }
        }

        private static Lazy<Func<ConfigurationOptions, Task<ConnectionMultiplexer>>> AsyncConnection() => new Lazy<Func<ConfigurationOptions, Task<ConnectionMultiplexer>>>(() => opts => ConnectionMultiplexer.ConnectAsync(opts), LazyThreadSafetyMode.ExecutionAndPublication);
        private static Lazy<Func<ConfigurationOptions, ConnectionMultiplexer>> NormalConnection() => new Lazy<Func<ConfigurationOptions, ConnectionMultiplexer>>(() => opts => ConnectionMultiplexer.Connect(opts), LazyThreadSafetyMode.ExecutionAndPublication);

        ~RedisContext() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_disposed && isDisposing && Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
            _disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (Connection != null && !_disposed)
            {
                await Connection.CloseAsync().ConfigureAwait(false);
                await Connection.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}