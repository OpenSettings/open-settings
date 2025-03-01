using Ogu.Response.Json;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for managing licenses, including retrieval, validation, 
    /// creation, and deletion of license data.
    /// </summary>
    public interface ILicensesService
    {
        /// <summary>
        /// Retrieves a paginated list of licenses based on the provided input.
        /// </summary>
        /// <param name="input">The input parameters for pagination and filtering.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IJsonResponse"/> 
        /// with the paginated list of licenses. See data type: <see cref="OpenSettings.Models.Responses.GetPaginatedLicensesResponse"/>.
        /// </returns>
        Task<IJsonResponse> GetPaginatedLicensesAsync(GetPaginatedLicensesInput input, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves the current active license. This method never returns a failure.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IJsonResponse"/> with the license data. See data type: <see cref="OpenSettings.Models.License"/>.</returns>
        Task<IJsonResponse<License>> GetCurrentLicenseAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the provided license key.
        /// </summary>
        /// <param name="licenseKey">The license key to be saved.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IJsonResponse"/> 
        /// with the license data. See data type: <see cref="OpenSettings.Models.License"/>.
        /// </returns>
        Task<IJsonResponse> SaveLicenseAsync(string licenseKey, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a license based on the provided input parameters.
        /// </summary>
        /// <param name="input">The input parameters required to delete the license.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IJsonResponse"/> 
        /// indicating the success or failure of the operation.
        /// </returns>
        Task<IJsonResponse> DeleteLicenseAsync(DeleteLicenseInput input, CancellationToken cancellationToken);
    }
}