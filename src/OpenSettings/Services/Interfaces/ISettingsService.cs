using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppSettingService
    {
        Task<IResponse> GetAppSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CopyAppSettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetAppSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppSettingByIdAsync(GetAppSettingByIdInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<UpdateAppSettingDataResponse>> UpdateAppSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken);
    }
}