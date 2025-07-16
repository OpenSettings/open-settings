using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class UsersRestService : IUserRestService
    {
        public Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public Task<IResponse> CreateUserAsync(CreateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetPaginatedUsersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetUserByIdAsync(GetUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetUserBySlugAsync(GetUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> UpdateUserAsync(UpdateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> DeleteUserAsync(DeleteUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}