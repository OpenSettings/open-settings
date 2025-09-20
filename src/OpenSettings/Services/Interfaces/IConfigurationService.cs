using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppConfigurationService
    {
        Task<IResponse> GetAppConfigurationByAppIdAndIdentifierIdAsync(GetAppConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> PatchAppConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default);
    }
}