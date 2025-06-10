using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<IResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default);

        Task<IResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken);
    }
}