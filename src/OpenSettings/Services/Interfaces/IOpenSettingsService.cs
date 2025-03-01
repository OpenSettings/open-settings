using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IOpenSettingsService
    {
        Task<GetConfigsResponse> GetConfigsAsync(CancellationToken cancellationToken = default);

        Task<GetConfigsDataResponse> GetConfigsDataAsync(string configName, CancellationToken cancellationToken = default);
    }
}