using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IInstanceService
    {
        Task<IResponse> CreateInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteInstanceAsync(DeleteInstanceInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default);
    }
}