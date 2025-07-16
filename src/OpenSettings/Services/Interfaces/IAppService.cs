using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppService
    {
        Task<IResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken = default);
    }
}