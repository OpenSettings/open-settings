using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class LicenseRestService : ILicenseRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LicenseRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedLicensesAsync(GetPaginatedLicensesInput input, CancellationToken cancellationToken)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.LicensesEndpoints.GetPaginatedLicenses,
                null,
                ("page", input.PaginatedInput.PageIndex),
                ("size", input.PaginatedInput.PageSize),
                (nameof(input.PaginatedInput.SearchTerm), input.PaginatedInput.SearchTerm),
                (nameof(input.PaginatedInput.SearchBy), input.PaginatedInput.SearchBy),
                (nameof(input.PaginatedInput.SortBy), input.PaginatedInput.SortBy),
                    (nameof(input.PaginatedInput.SortDirection), input.PaginatedInput.SortDirection));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<License>> GetCurrentLicenseAsync(CancellationToken cancellationToken)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.LicensesEndpoints.GetCurrentLicense;

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<License>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> SaveLicenseAsync(string licenseKey, CancellationToken cancellationToken)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.LicensesEndpoints.SaveLicense;

            using (var stringContent = new StringContent($"\"{licenseKey}\"", Encoding.UTF8, OpenSettingsDefaults.ContentTypes.ApplicationJson))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DeleteLicenseAsync(DeleteLicenseInput input, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input.ReferenceId))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.ReferenceIdMustNotEmpty);
            }

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.LicensesEndpoints.DeleteLicense,
                new[] { input.ReferenceId });

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}