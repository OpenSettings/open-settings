using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql.Interfaces
{
    internal interface ITokenSqlService : ITokenService
    {
        ValueTask<ProviderTokenInfo> GetProviderTokenInfoAsync(CancellationToken cancellationToken);

        Task<GenerateTokenResponse> GenerateTokenForUserAsync(GenerateTokenForUserInput input, CancellationToken cancellationToken);
    }
}