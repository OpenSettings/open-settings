using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IInstancesService
    {
        Task<IJsonResponse> UpdateInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteInstanceAsync(DeleteInstanceInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);
    }
}