using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppIdentifierMappingsService
    {
        Task<IJsonResponse> CreateAppIdentifierMappingAsync(CreateAppIdentifierMappingInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteAppIdentifierMappingAsync(DeleteAppIdentifierMappingInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetAppIdentifierMappingsByAppIdAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateAppIdentifierMappingSortOrderAsync(UpdateAppIdentifierMappingSortOrderInput input, CancellationToken cancellationToken = default);
    }
}