using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ISettingHistoryService
    {
        Task<IResponse> GetSettingHistoryDataAsync(GetSettingHistoryDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingHistoryByIdAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingHistoryBySlugAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default);

        Task<IResponse<RestoreSettingHistoryResponse>> RestoreSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken = default);
    }
}