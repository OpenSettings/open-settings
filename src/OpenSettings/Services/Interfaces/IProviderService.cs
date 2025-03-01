using Ogu.Response.Json;
using OpenSettings.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IProviderService
    {
        Task<IJsonResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default);
    }
}