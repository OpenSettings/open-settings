using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ISettingHistoriesService
    {
        Task<IJsonResponse> GetSettingHistoryDataAsync(GetSettingHistoryDataInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingHistoryByIdAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingHistoryBySlugAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<RestoreSettingHistoryResponse>> RestoreSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken = default);
    }
}