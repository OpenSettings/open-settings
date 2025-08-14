using OpenSettings.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IGlobalConfigurationSqlService : IGlobalConfigurationService
    {
        Task<TokenKeySet> GetTokenKeySetAsync(CancellationToken cancellationToken);
    }
}