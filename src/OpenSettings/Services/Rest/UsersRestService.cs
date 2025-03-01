using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class UsersRestService : IUsersRestService
    {
        public Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}