using Ogu.Response.Abstractions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IResponse<IsAuthenticatedResponse>> IsAuthenticatedAsync(IsAuthenticatedInput input, CancellationToken cancellationToken = default);

        void ReturnTo(ReturnToInput input);

        Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default);

        Task LogoutAsync(LogoutInput input, CancellationToken cancellationToken = default);

        Task<IResponse<WhoAmIResponse>> WhoAmIAsync(WhoAmIInput input, CancellationToken cancellationToken = default);
    }
}