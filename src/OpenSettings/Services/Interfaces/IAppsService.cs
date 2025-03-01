using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppsService
    {
        Task<IJsonResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken = default);
    }
}