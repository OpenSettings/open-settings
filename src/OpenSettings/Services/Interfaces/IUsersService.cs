using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IUsersService
    {
        Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateUserAsync(CreateUserInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetPaginatedUsersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetUserByIdAsync(GetUserInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetUserBySlugAsync(GetUserInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateUserAsync(UpdateUserInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUserAsync(DeleteUserInput input, CancellationToken cancellationToken = default);
    }
}