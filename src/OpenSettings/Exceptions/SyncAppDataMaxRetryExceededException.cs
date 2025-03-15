using System;

namespace OpenSettings.Exceptions
{
    public class SyncAppDataMaxRetryExceededException : Exception
    {
        public SyncAppDataMaxRetryExceededException(int maxRetryCount, int attempt) : base($"SyncAppData max retry limit exceeded. MaxRetryCount: {maxRetryCount}, Attempt: {attempt}")
        {
            MaxRetryCount = maxRetryCount;
            Attempt = attempt;
        }

        public int MaxRetryCount { get; }

        public int Attempt { get; }
    }
}