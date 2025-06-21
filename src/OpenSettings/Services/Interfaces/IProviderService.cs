using Ogu.Response.Abstractions;
using OpenSettings.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IProviderService
    {
        Task<IResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default);
    }
}