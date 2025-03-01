using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IConfigurationsService
    {
        Task<IJsonResponse> GetConfigurationByAppIdAndIdentifierIdAsync(GetConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> PatchConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default);
    }
}