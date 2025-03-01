using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IDataChangeService
    {
        Task NotifyChangeAsync(Guid clientId, string identifierName, Guid classComputedIdentifier, CancellationToken cancellationToken);
    }
}