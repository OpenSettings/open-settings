using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AppsController : ControllerBase
    {
        private readonly IAppService _appsService;
        private readonly IAppSettingService _appSettingService;
        private readonly IInstanceService _appInstanceService;
        private readonly IAppIdentifierMappingService _appIdentifierMappingsService;
        private readonly IAppConfigurationService _appConfigurationService;

        public AppsController(IAppService appsService, IAppSettingService appSettingService, IInstanceService appInstanceService, IAppIdentifierMappingService appIdentifierMappingsService, IAppConfigurationService appConfigurationService)
        {
            _appsService = appsService;
            _appSettingService = appSettingService;
            _appInstanceService = appInstanceService;
            _appIdentifierMappingsService = appIdentifierMappingsService;
            _appConfigurationService = appConfigurationService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetApps)]
        public async Task<IActionResult> GetApps(GetAppsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetAppsAsync(new GetAppsInput
            {
                SearchTerm = request.SearchTerm
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateApp)]
        public async Task<IActionResult> CreateApp(CreateAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.CreateAppAsync(new CreateAppInput
            {
                DisplayName = request.Body.DisplayName,
                Client = new CreateAppInputClient
                {
                    Id = request.Body.Client.Id,
                    Name = request.Body.Client.Name,
                    Secret = request.Body.Client.Secret
                },
                Slug = request.Body.Slug,
                Group = request.Body.Group == null
                    ? null
                    : new CreateAppInputGroup
                    {
                        Id = request.Body.Group.Id,
                        Name = request.Body.Group.Name,
                        SortOrder = request.Body.Group.SortOrder
                    },
                Description = request.Body.Description,
                ImageUrl = request.Body.ImageUrl,
                WikiUrl = request.Body.WikiUrl,
                Tags = request.Body.Tags.Select(t => new CreateAppInputTag
                {
                    Id = t.Id,
                    Name = t.Name,
                    SortOrder = t.SortOrder
                }).ToArray(),
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedApps)]
        public async Task<IActionResult> GetGroupedApps(GetGroupedAppsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetGroupedAppsAsync(new GetGroupedAppsInput
            {
                AppGroupId = request.GroupId,
                SearchTerm = request.SearchTerm
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.FetchAppData)]
        public async Task<IActionResult> FetchAppData(FetchAppDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.FetchAppDataAsync(new FetchAppDataInput
            {
                ClientId = request.ClientId,
                IdentifierName = request.IdentifierName,
                ComputedIdentifiers = request.Body.ComputedIdentifiers,
                StoreInSeparateFile = request.Body.StoreInSeparateFile
            }, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.SyncAppData)]
        [Authorize(AuthenticationSchemes = OpenSettingsDefaults.AuthSchemes.Basic)]
        public async Task<IActionResult> SyncAppData(SyncAppDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            if (request.Body.Instance != null)
            {
                request.Body.Instance.RemoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            }

            var result = await _appsService.SyncAppDataAsync(new SyncAppDataInput
            {
                Client = new SyncAppDataInputClient
                {
                    Id = request.ClientId,
                    Name = request.Body.Client.Name,
                    Secret = request.Body.Client.Secret
                },
                IdentifierName = request.IdentifierName,
                Configuration = request.Body.Configuration,
                Settings = request.Body.Settings,
                Instance = request.Body.Instance,
                UserId = User.GetUserDisplayName() == string.Empty ? null : User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppByAppId)]
        public async Task<IActionResult> GetAppById(GetAppByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetAppByIdAsync(new GetAppInput
            {
                AppIdOrSlug = request.AppId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppByAppSlug)]
        public async Task<IActionResult> GetAppBySlug(GetAppBySlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetAppBySlugAsync(new GetAppInput
            {
                AppIdOrSlug = request.AppSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateApp)]
        public async Task<IActionResult> UpdateApp(UpdateAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var response = await _appsService.UpdateAppAsync(new UpdateAppInput
            {
                AppId = request.AppId,
                DisplayName = request.Body.DisplayName,
                ClientName = request.Body.Client.Name,
                Slug = request.Body.Slug,
                Description = request.Body.Description,
                ImageUrl = request.Body.ImageUrl,
                WikiUrl = request.Body.WikiUrl,
                Group = request.Body.Group == null
                    ? null
                    : new UpdateAppInputGroup
                    {
                        Name = request.Body.Group.Name
                    },
                Tags = request.Body.Tags.Select(t => new UpdateAppInputTag
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArray(),
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return response.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppsEndpoints.DeleteApp)]
        public async Task<IActionResult> DeleteApp(DeleteAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.DeleteAppAsync(new DeleteAppInput
            {
                AppId = request.AppId,
                RowVersion = request.RowVersion,
                DeletedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppId)]
        public async Task<IActionResult> GetGroupedAppDataByAppId(GetGroupedAppDataByAppIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppIdAsync(new GetGroupedAppDataByAppInput { AppIdOrSlug = request.AppId }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppSlug)]
        public async Task<IActionResult> GetGroupedAppDataByAppSlug(GetGroupedAppDataByAppSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppSlugAsync(new GetGroupedAppDataByAppInput { AppIdOrSlug = request.AppSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppId)]
        public async Task<IActionResult> GetAppInstancesByAppId(GetAppInstancesByAppIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.GetAppInstancesByAppIdAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppId,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppSlug)]
        public async Task<IActionResult> GetAppInstancesByAppSlug(GetAppInstancesByAppSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.GetAppInstancesByAppSlugAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppSlug,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateAppInstance)]
        public async Task<IActionResult> CreateAppInstance(CreateAppInstanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.CreateAppInstanceAsync(new CreateInstanceInput
            {
                ClientId = request.ClientId,
                ClientSecret = request.Body.ClientSecret,
                InstanceName = request.Body.InstanceName,
                IdentifierName = request.Body.IdentifierName,
                DynamicId = request.Body.DynamicId,
                Urls = request.Body.Urls,
                Version = request.Body.Version,
                IsActive = request.Body.IsActive,
                RemoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                MachineName = request.Body.MachineName,
                Environment = request.Body.Environment,
                ReloadStrategies = request.Body.ReloadStrategies,
                ServiceType = request.Body.ServiceType,
                DataAccessType = request.Body.DataAccessType,
                CreatedById = User.GetUserId()
            }, CancellationToken.None);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateAppInstance)]
        public async Task<IActionResult> UpdateAppInstance(UpdateAppInstanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.UpdateAppInstanceAsync(new UpdateInstanceInput
            {
                ClientId = request.ClientId,
                ClientSecret = request.Body.ClientSecret,
                InstanceName = request.Body.InstanceName,
                IdentifierName = request.Body.IdentifierName,
                Urls = request.Body.Urls,
                IsActive = request.Body.IsActive,
                RemoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                UpdatedById = User.GetUserId()
            }, CancellationToken.None);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetRegisteredApp)]
        public async Task<IActionResult> GetRegisteredApp(GetRegisteredAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetRegisteredAppAsync(new GetRegisteredAppInput
            {
                ClientId = request.ClientId,
                ClientSecret = request.ClientSecret
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingsByAppId)]
        public async Task<IActionResult> GetAppIdentifierMappingsByAppId(GetAppIdentifierMappingsByAppIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingsByAppIdAsync(
                new GetAppIdentifierMappingsInput { AppIdOrSlug = request.AppId }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingsByAppSlug)]
        public async Task<IActionResult> GetAppIdentifierMappingsByAppSlug(GetAppIdentifierMappingsByAppSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingsByAppSlugAsync(new GetAppIdentifierMappingsInput
            {
                AppIdOrSlug = request.AppSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateAppIdentifierMapping)]
        public async Task<IActionResult> CreateAppIdentifierMapping(CreateAppIdentifierMappingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }
            
            var result = await _appIdentifierMappingsService.CreateAppIdentifierMappingAsync(new CreateAppIdentifierMappingInput
            {
                AppId = request.AppId,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                Identifier = request.Body.Identifier == null
                    ? null
                    : new CreateAppIdentifierMappingInputIdentifier
                    {
                        Id = request.Body.Identifier.Id,
                        Name = request.Body.Identifier.Name
                    },
                UserId = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingByAppIdAndIdentifierId)]
        public async Task<IActionResult> GetAppIdentifierMappingByAppIdAndIdentifierId(GetAppIdentifierMappingByAppIdAndIdentifierIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(new GetAppIdentifierMappingByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppId,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingByAppSlugAndIdentifierSlug)]
        public async Task<IActionResult> GetAppIdentifierMappingByAppSlugAndIdentifierSlug(GetAppIdentifierMappingByAppSlugAndIdentifierSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(new GetAppIdentifierMappingByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppSlug,
                IdentifierIdOrSlug = request.IdentifierSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppConfigurationByAppIdAndIdentifierId)]
        public async Task<IActionResult> GetAppConfigurationByAppIdAndIdentifierId(GetAppConfigurationByAppIdAndIdentifierIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appConfigurationService.GetAppConfigurationByAppIdAndIdentifierIdAsync(new GetAppConfigurationByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppId,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPatch(OpenSettingsDefaults.Routes.V1.AppsEndpoints.PatchAppConfiguration)]
        public async Task<IActionResult> PatchAppConfiguration(PatchConfigurationRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appConfigurationService.PatchAppConfigurationAsync(new PatchAppConfigurationInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Body = new PatchAppConfigurationInputBody(request.Body.RowVersion, request.Body.UpdatedFieldNameToValue),
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppsEndpoints.DeleteAppIdentifierMapping)]
        public async Task<IActionResult> DeleteAppIdentifierMapping(DeleteAppIdentifierMappingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.DeleteAppIdentifierMappingAsync(
                new DeleteAppIdentifierMappingInput
                {
                    AppId = request.AppId,
                    IdentifierId = request.IdentifierId,
                    RowVersion = request.RowVersion
                }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppIdAndIdentifierId)]
        public async Task<IActionResult> GetAppInstancesByAppIdAndIdentifierId(GetAppInstancesByAppIdAndIdentifierIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.GetAppInstancesByAppIdAndIdentifierIdAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppId,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppSlugAndIdentifierSlug)]
        public async Task<IActionResult> GetAppInstancesByAppSlugAndIdentifierSlug(GetAppInstancesByAppSlugAndIdentifierSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appInstanceService.GetAppInstancesByAppSlugAndIdentifierSlugAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppSlug,
                IdentifierIdOrSlug = request.IdentifierSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsByAppIdAndIdentifierId)]
        public async Task<IActionResult> GetAppSettingsByAppIdAndIdentifierId(GetAppSettingsByAppIdAndIdentifierIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.GetAppSettingsByAppIdAndIdentifierIdAsync(
                new GetAppSettingsByAppAndIdentifierInput
                {
                    AppIdOrSlug = request.AppId,
                    IdentifierIdOrSlug = request.IdentifierId
                }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsByAppSlugAndIdentifierSlug)]
        public async Task<IActionResult> GetAppSettingsByAppSlugAndIdentifierSlug(GetAppSettingsByAppSlugAndIdentifierSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.GetAppSettingsByAppSlugAndIdentifierSlugAsync(
                new GetAppSettingsByAppAndIdentifierInput
                {
                    AppIdOrSlug = request.AppSlug,
                    IdentifierIdOrSlug = request.IdentifierSlug
                }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateAppIdentifierMappingSortOrder)]
        public async Task<IActionResult> UpdateAppIdentifierMappingSortOrder(UpdateAppIdentifierMappingSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appIdentifierMappingsService.UpdateAppIdentifierMappingSortOrderAsync(new UpdateAppIdentifierMappingSortOrderInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Direction = request.Body.Direction,
                RowVersion = request.Body.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppIdAndIdentifierId)]
        public async Task<IActionResult> GetGroupedAppDataByAppIdAndIdentifierId(GetGroupedAppDataByAppIdAndIdentifierIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppIdAndIdentifierIdAsync(new GetGroupedAppDataByAppAndIdentifierInput { AppIdOrSlug = request.AppId, IdentifierIdOrSlug = request.IdentifierId }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppSlugAndIdentifierSlug)]
        public async Task<IActionResult> GetGroupedAppDataByAppSlugAndIdentifierSlug(GetGroupedAppDataByAppSlugAndIdentifierSlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(new GetGroupedAppDataByAppAndIdentifierInput { AppIdOrSlug = request.AppSlug, IdentifierIdOrSlug = request.IdentifierSlug }, cancellationToken);

            return result.ToAction();
        }
        
        [HttpGet(OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsData)]
        public async Task<IActionResult> GetAppSettingsData(GetAppSettingsDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.GetAppSettingsDataAsync(new GetAppSettingsDataInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Ids = request.Ids
            }, cancellationToken);

            return result.ToAction();
        }
    }
}