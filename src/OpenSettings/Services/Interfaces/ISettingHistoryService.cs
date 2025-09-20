using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ISettingHistoryService
    {
        Task<IResponse> GetAppSettingHistoryDataAsync(GetAppSettingHistoryDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingHistoryByIdAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingHistoryBySlugAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default);

        Task<IResponse<RestoreSettingHistoryResponse>> RestoreAppSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken = default);
    }
}