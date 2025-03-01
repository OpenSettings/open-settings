using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IUsersService
    {
        Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken);
    }
}