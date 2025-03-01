using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Services.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly string _route;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly OpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ProviderInfo _providerInfo;
        private readonly IOpenSettingsTokenService _tokenService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(
            OpenSettingsMemoryCache openSettingsMemoryCache,
            ControllerOptions controllerOptions,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo,
            IOpenSettingsTokenService tokenService,
            IHttpClientFactory httpClientFactory)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _route = controllerOptions.Route;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
            _tokenService = tokenService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("authenticated")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticated(string uuid)
        {
            if (!string.IsNullOrWhiteSpace(uuid) && _openSettingsMemoryCache.TryGetValue($"accessToken:{uuid}", out var accessToken))
            {
                return Ok(new AuthenticatedResponse
                {
                    IsAuthenticated = true,
                    AccessToken = $"{accessToken}"
                });
            }

            if (User.Identity?.IsAuthenticated ?? false)
            {
                return Ok(new AuthenticatedResponse
                {
                    IsAuthenticated = true
                });
            }

            var authHeader = Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader?.Parameter != "Basic")
            {
                return Ok(new AuthenticatedResponse
                {
                    IsAuthenticated = false
                });
            }

            var authenticateResult = await HttpContext.AuthenticateAsync(OpenSettings.Constants.OpenSettingsBasicAuthScheme);

            return Ok(new AuthenticatedResponse
            {
                IsAuthenticated = authenticateResult.Succeeded
            });
        }

        [HttpGet("who-am-i")]
        public async Task<IActionResult> WhoAmI([FromQuery] string claimTypes, CancellationToken cancellationToken)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                return Unauthorized();
            }

            var authorizationHeader = Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (_openSettingsConfiguration.IsConsumerSelected)
            {
                var httpClient = _httpClientFactory.CreateClient();

                httpClient.DefaultRequestHeaders.Authorization = authorizationHeader;

                var response = await httpClient.GetAsync($"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/who-am-i", HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    this.Response.StatusCode = (int)response.StatusCode;
                    return new EmptyResult();
                }

                var stream = await response.Content.ReadAsStreamAsync();

                var outputStream = Response.Body;

                await stream.CopyToAsync(outputStream);

                await outputStream.FlushAsync(cancellationToken);

                return new EmptyResult();
            }

            var claims = _openSettingsMemoryCache.TryGetValue<Claim[]>(authorizationHeader.Parameter, out var claimsFromCache)
                ? claimsFromCache
                : User.Claims;

            if (string.IsNullOrWhiteSpace(claimTypes))
            {
                var claimTypeToValue = claims.GroupBy(c => c.Type)
                    .ToDictionary(c => c.Key, c => string.Join(",", c.Select(claim => claim.Value)));

                return Ok(claimTypeToValue);
            }

            var claimArray = claimTypes
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(claimType => claimType.Trim())
                .Where(claimType => claimType != string.Empty)
                .Distinct()
                .ToArray();

            var filteredClaimTypeToValue = claims
                .GroupBy(c => c.Type)
                .Select(c => new { Type = c.Key, Value = string.Join(",", c.Select(claim => claim.Value)) })
                .Where(claim => claimArray.Contains(claim.Type))
                .OrderBy(claim => Array.IndexOf(claimArray, claim.Type))
                .ToDictionary(c => c.Type, c => c.Value);

            return Ok(filteredClaimTypeToValue);
        }

        [HttpGet("return-to")]
        [AllowAnonymous]
        public IActionResult ReturnTo([FromQuery] string returnUrl, [FromQuery] string accessToken, [FromQuery] string uuid)
        {
            if (_openSettingsConfiguration.IsConsumerSelected)
            {
                _openSettingsMemoryCache.Set($"accessToken:{uuid}", accessToken, DateTimeOffset.Now.AddMinutes(5));
            }

            return Redirect(returnUrl);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] string returnUrl, [FromQuery] string apiUrl, [FromQuery] string uuid)
        {
            var isSelectedRest = _openSettingsConfiguration.IsConsumerSelected;

            var authenticateResult = await HttpContext.AuthenticateAsync(isSelectedRest
                ? Constants.OpenSettingsOAuth2JwtBearerScheme
                : OpenSettings.Constants.OpenSettingsOAuth2Scheme);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = HttpContext.Request.Headers["Referer"].ToString().TrimEnd('/');
            }

            if (authenticateResult.Succeeded)
            {
                if (authenticateResult.Properties.Items.TryGetValue("ReturnUrl", out var returnUrlFromItem) &&
                    string.IsNullOrWhiteSpace(returnUrl))
                {
                    returnUrl = returnUrlFromItem;
                }

                if (authenticateResult.Properties.Items.TryGetValue("ApiUrl", out var apiUrlFromItem) &&
                    string.IsNullOrWhiteSpace(apiUrl))
                {
                    apiUrl = apiUrlFromItem;
                }

                if (authenticateResult.Properties.Items.TryGetValue("uuid", out var uuidFromItem) &&
                    string.IsNullOrWhiteSpace(uuid))
                {
                    uuid = uuidFromItem;
                }

                if (apiUrl.StartsWith(GetBaseUrl()))
                {
                    return Redirect(returnUrl);
                }

                var accessToken = await HttpContext.GetTokenAsync(OpenSettings.Constants.OpenSettingsCookieScheme, "access_token");

                _openSettingsMemoryCache.Set(accessToken, User.Claims.ToArray(), new MemoryCacheEntryOptions{ SlidingExpiration = TimeSpan.FromHours(1)});

                if (!await _tokenService.IsTokenExpiredAsync(HttpContext, accessToken))
                {
                    var returnToUrl = $"{apiUrl}/v1/auth/return-to?returnUrl={returnUrl}&accessToken={accessToken}&uuid={uuid}";

                    return Redirect(returnToUrl);
                }

                await HttpContext.SignOutAsync(OpenSettings.Constants.OpenSettingsCookieScheme);
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = $"{Request.Scheme}://{Request.Host}/";
            }

            if (string.IsNullOrEmpty(apiUrl))
            {
                apiUrl = $"{Request.Scheme}://{Request.Host}/{_route}";
            }

            if (isSelectedRest)
            {
                return Redirect($"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/login?returnUrl={returnUrl}&apiUrl={apiUrl}&uuid={uuid}");
            }

            try
            {
                return Challenge(new AuthenticationProperties(new Dictionary<string, string>()
                {
                    { "ReturnUrl", returnUrl },
                    { "ApiUrl", apiUrl },
                    { "uuid", uuid }
                }), OpenSettings.Constants.OpenSettingsOAuth2Scheme);
            }
            catch
            {
                return Redirect(returnUrl);
            }
        }

        [HttpGet("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout([FromQuery] string returnUrl, [FromQuery] string apiUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = HttpContext.Request.Headers["Referer"].ToString().TrimEnd('/');
            }

            if (_openSettingsConfiguration.IsProviderSelected)
            {
                try
                {
                    var response = await _httpClientFactory.CreateClient().GetAsync($"{_providerInfo.OAuth2.Authority.TrimEnd('/')}/.well-known/openid-configuration");

                    if (response.IsSuccessStatusCode)
                    {
                        return SignOut(OpenSettings.Constants.OpenSettingsCookieScheme, OpenSettings.Constants.OpenSettingsOAuth2Scheme);
                    }

                    await HttpContext.SignOutAsync(OpenSettings.Constants.OpenSettingsCookieScheme);

                    return Redirect(returnUrl);
                }
                catch
                {
                    await HttpContext.SignOutAsync(OpenSettings.Constants.OpenSettingsCookieScheme);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return StatusCode(500, "Identity service isn't accessible at this moment!");
                }
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetBaseUrl();
            }

            if (string.IsNullOrEmpty(apiUrl))
            {
                apiUrl = $"{GetBaseUrl()}/{_route}";
            }

            return Redirect($"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/logout?returnUrl={returnUrl}&apiUrl={apiUrl}");
        }

        [HttpPost("refresh-token")]
        [Authorize(AuthenticationSchemes = Constants.OpenSettingsOAuth2JwtBearerScheme)]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken = default)
        {
            var refreshToken = await _tokenService.RefreshTokenAsync(HttpContext, cancellationToken);

            if (refreshToken == null)
            {
                return Forbid();
            }

            return Ok(refreshToken);
        }

        private string GetBaseUrl() => $"{Request.Scheme}://{Request.Host}";
    }
}