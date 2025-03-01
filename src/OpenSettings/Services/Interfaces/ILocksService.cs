using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ILocksService 
    {
        Task<bool> AcquireLockAsync(AcquireLockInput input, CancellationToken cancellationToken = default);

        Task SetLockExpiryTimeAsync(SetLockExpiryTimeInput input, CancellationToken cancellationToken);

        Task<bool> ReleaseLockAsync(ReleaseLockInput input, CancellationToken cancellationToken = default);
    }
}