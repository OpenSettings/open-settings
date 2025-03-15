using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenSettings.Models;

namespace OpenSettings.Services.Rest
{
    public class LicensesRestService : ILicensesRestService
    {
        private readonly HttpClient _httpClient;

        public LicensesRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetPaginatedLicensesAsync(GetPaginatedLicensesInput input, CancellationToken cancellationToken)
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

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse<License>> GetCurrentLicenseAsync(CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/licenses/current";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync<License>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> SaveLicenseAsync(string licenseKey, CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/licenses";

            using (var stringContent = new StringContent($"\"{licenseKey}\"", Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> DeleteLicenseAsync(DeleteLicenseInput input, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input.ReferenceId))
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.ReferenceIdMustNotEmpty);
            }

            var relativeUri = $"v1/licenses/{Uri.EscapeDataString(input.ReferenceId)}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}