using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<IJsonResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken);
    }
}