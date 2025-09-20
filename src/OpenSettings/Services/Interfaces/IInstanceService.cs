using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IInstanceService
    {
        Task<IResponse> CreateAppInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppInstanceAsync(DeleteAppInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);
    }
}