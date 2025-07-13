using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class LicensesRestService : ILicensesRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public LicensesRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedLicensesAsync(GetPaginatedLicensesInput input, CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/licenses/paginated";

            var queryBuilder = new QueryBuilder()
                .Append("page", input.PaginatedInput.PageIndex)
                .Append("size", input.PaginatedInput.PageSize);

            if (!string.IsNullOrWhiteSpace(input.PaginatedInput.SearchTerm))
            {
                queryBuilder.Append(nameof(input.PaginatedInput.SearchTerm), input.PaginatedInput.SearchTerm);
            }

            if (!string.IsNullOrWhiteSpace(input.PaginatedInput.SearchBy))
            {
                queryBuilder.Append(nameof(input.PaginatedInput.SearchBy), input.PaginatedInput.SearchBy);
            }

            if (!string.IsNullOrWhiteSpace(input.PaginatedInput.SortBy))
            {
                queryBuilder.Append(nameof(input.PaginatedInput.SortBy), input.PaginatedInput.SortBy);
            }

            queryBuilder.Append(nameof(input.PaginatedInput.SortDirection), input.PaginatedInput.SortDirection);

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<License>> GetCurrentLicenseAsync(CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/licenses/current";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<License>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> SaveLicenseAsync(string licenseKey, CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/licenses";

            using (var stringContent = new StringContent($"\"{licenseKey}\"", Encoding.UTF8, OpenSettingsDefaults.ContentTypes.ApplicationJson))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, stringContent, cancellationToken))
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

            var relativeUri = $"v1/licenses/{Uri.EscapeDataString(input.ReferenceId)}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}