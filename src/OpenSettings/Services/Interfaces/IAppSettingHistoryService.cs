using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppSettingHistoryService
    {
        Task<IResponse> GetAppSettingHistoryDataAsync(GetAppSettingHistoryDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingHistoryByIdAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingHistoryBySlugAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingHistoriesAsync(GetAppSettingHistoriesInput input, CancellationToken cancellationToken = default);

        Task<IResponse<RestoreAppSettingHistoryResponse>> RestoreAppSettingHistoryAsync(RestoreAppSettingHistoryInput input, CancellationToken cancellationToken = default);
    }
}