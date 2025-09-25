using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppSettingService
    {
        Task<IResponse> GetAppSettingsByAppIdAndIdentifierIdAsync(GetAppSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingsByAppSlugAndIdentifierSlugAsync(GetAppSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingsDataAsync(GetAppSettingsDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CopyAppSettingToAsync(CopyAppSettingToInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingDataAsync(GetAppSettingDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppSettingAsync(DeleteAppSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetAppSettingsLastUpdatedComputedIdentifiersAsync(GetAppSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingByIdAsync(GetAppSettingByIdInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppSettingAsync(UpdateAppSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppSettingAsync(CreateAppSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<UpdateAppSettingDataResponse>> UpdateAppSettingDataAsync(UpdateAppSettingDataInput input, CancellationToken cancellationToken);
    }
}