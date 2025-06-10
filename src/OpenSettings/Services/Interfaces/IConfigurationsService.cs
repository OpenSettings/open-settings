using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IConfigurationsService
    {
        Task<IResponse> GetConfigurationByAppIdAndIdentifierIdAsync(GetConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> PatchConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default);
    }
}