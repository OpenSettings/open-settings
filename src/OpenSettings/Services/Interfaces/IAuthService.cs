using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IResponse<GetMeResponse>> GetMeAsync(GetMeInput input, CancellationToken cancellationToken = default);

        void ReturnTo(ReturnToInput input);

        Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default);

        Task LogoutAsync(LogoutInput input, CancellationToken cancellationToken = default);
    }
}