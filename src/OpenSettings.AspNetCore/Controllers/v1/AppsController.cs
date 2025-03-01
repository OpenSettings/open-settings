using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/apps")]
    public class AppsController : ControllerBase
    {
        private readonly IAppsService _appsService;
        private readonly ISettingsService _settingsService;
        private readonly IInstancesService _instancesService;
        private readonly IAppIdentifierMappingsService _appIdentifierMappingsService;
        private readonly IConfigurationsService _configurationsService;

        public AppsController(IAppsService appsService, ISettingsService settingsService, IInstancesService instancesService, IAppIdentifierMappingsService appIdentifierMappingsService, IConfigurationsService configurationsService)
        {
            _appsService = appsService;
            _settingsService = settingsService;
            _instancesService = instancesService;
            _appIdentifierMappingsService = appIdentifierMappingsService;
            _configurationsService = configurationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApps(GetAppsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetAppsAsync(new GetAppsInput
            {
                SearchTerm = request.SearchTerm
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> CreateApp(CreateAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

        [HttpGet("grouped")]
        public async Task<IActionResult> GetGroupedApps(GetGroupedAppsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetGroupedAppsAsync(new GetGroupedAppsInput
            {
                GroupId = request.GroupId,
                SearchTerm = request.SearchTerm
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{ClientId:guid}/identifiers/{IdentifierName}/fetch-data")]
        public async Task<IActionResult> FetchAppData(FetchAppDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

        [HttpPost("{ClientId:guid}/identifiers/{IdentifierName}/sync-data")]
        public async Task<IActionResult> SyncAppData(SyncAppDataRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

            return Ok(result);
        }

        [HttpGet("{AppIdOrSlug}")]
        public async Task<IActionResult> GetAppById(GetAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetAppByIdAsync(new GetAppInput
            {
                AppIdOrSlug = request.AppIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}")]
        public async Task<IActionResult> GetAppBySlug(GetAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetAppBySlugAsync(new GetAppInput
            {
                AppIdOrSlug = request.AppIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{AppId}")]
        public async Task<IActionResult> UpdateApp(UpdateAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

        [HttpDelete("{AppId}")]
        public async Task<IActionResult> DeleteApp(DeleteAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.DeleteAppAsync(new DeleteAppInput
            {
                AppId = request.AppId,
                RowVersion = request.RowVersion,
                DeletedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{AppIdOrSlug}/grouped")]
        public async Task<IActionResult> GetGroupedAppDataByAppId(GetGroupedAppDataByAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppIdAsync(new GetGroupedAppDataByAppInput { AppIdOrSlug = request.AppIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}/grouped")]
        public async Task<IActionResult> GetGroupedAppDataByAppSlug(GetGroupedAppDataByAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppSlugAsync(new GetGroupedAppDataByAppInput { AppIdOrSlug = request.AppIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{AppIdOrAppSlug}/instances")]
        public async Task<IActionResult> GetInstancesByAppId(GetInstancesByAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.GetInstancesByAppIdAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppIdOrAppSlug,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrAppSlug}/instances")]
        public async Task<IActionResult> GetInstancesByAppSlug(GetInstancesByAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.GetInstancesByAppSlugAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppIdOrAppSlug,
                IdentifierIdOrSlug = request.IdentifierId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{ClientId:guid}/instances")]
        public async Task<IActionResult> UpdateInstance(UpdateInstanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.UpdateInstanceAsync(new UpdateInstanceInput
            {
                ClientId = request.ClientId,
                InstanceName = request.Body.InstanceName,
                IdentifierName = request.Body.IdentifierName,
                Urls = request.Body.Urls,
                IsActive = request.Body.IsActive,
                IpAddress = Request.GetIpAddress(),
                UpdatedById = User.GetUserId()
            }, CancellationToken.None);

            return result.ToAction();
        }

        [HttpPost("{ClientId:guid}/registered")]
        public async Task<IActionResult> GetRegisteredApp(GetRegisteredAppRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetRegisteredAppAsync(new GetRegisteredAppInput
            {
                ClientId = request.ClientId,
                ClientSecret = request.ClientSecret
            }, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{AppIdOrSlug}/identifiers")]
        public async Task<IActionResult> GetAppIdentifierMappingsByAppId(GetAppIdentifierMappingsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingsByAppIdAsync(
                new GetAppIdentifierMappingsInput { AppIdOrSlug = request.AppIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}/identifiers")]
        public async Task<IActionResult> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingsByAppSlugAsync(new GetAppIdentifierMappingsInput
            {
                AppIdOrSlug = request.AppIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{AppId}/identifiers")]
        public async Task<IActionResult> CreateAppIdentifierMapping(CreateAppIdentifierMappingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

        [HttpGet("{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetAppIdentifierMappingByAppIdAndIdentifierId(GetAppIdentifierMappingByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(new GetAppIdentifierMappingByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppIdOrSlug,
                IdentifierIdOrSlug = request.IdentifierIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetAppIdentifierMappingByAppSlugAndIdentifierSlug(GetAppIdentifierMappingByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appIdentifierMappingsService.GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(new GetAppIdentifierMappingByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppIdOrSlug,
                IdentifierIdOrSlug = request.IdentifierIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}/configuration")]
        public async Task<IActionResult> GetConfigurationByAppIdAndIdentifierId(GetConfigurationByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _configurationsService.GetConfigurationByAppIdAndIdentifierIdAsync(new GetConfigurationByAppAndIdentifierInput
            {
                AppIdOrSlug = request.AppIdOrSlug,
                IdentifierIdOrSlug = request.IdentifierIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPatch("{AppId}/identifiers/{IdentifierId}/configuration")]
        public async Task<IActionResult> PatchConfiguration(PatchConfigurationRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _configurationsService.PatchConfigurationAsync(new PatchConfigurationInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Body = new PatchConfigurationInputBody(request.Body.RowVersion, request.Body.UpdatedFieldNameToValue),
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{AppId}/identifiers/{IdentifierId}")]
        public async Task<IActionResult> DeleteAppIdentifierMapping(DeleteAppIdentifierMappingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
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

        [HttpGet("{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}/instances")]
        public async Task<IActionResult> GetInstancesByAppIdAndIdentifierId(GetInstancesByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.GetInstancesByAppIdAndIdentifierIdAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppIdOrSlug,
                IdentifierIdOrSlug = request.IdentifierIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}/instances")]
        public async Task<IActionResult> GetInstancesByAppSlugAndIdentifierSlug(GetInstancesByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.GetInstancesByAppSlugAndIdentifierSlugAsync(new GetInstancesInput
            {
                AppIdOrSlug = request.AppIdOrSlug,
                IdentifierIdOrSlug = request.IdentifierIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{AppIdOrAppSlug}/identifiers/{IdentifierIdOrSlug}/settings")]
        public async Task<IActionResult> GetSettingsByAppIdAndIdentifierId(GetSettingsByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.GetSettingsByAppIdAndIdentifierIdAsync(
                new GetSettingsByAppAndIdentifierInput
                {
                    AppIdOrSlug = request.AppIdOrAppSlug,
                    IdentifierIdOrSlug = request.IdentifierIdOrSlug
                }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrAppSlug}/identifiers/{IdentifierIdOrSlug}/settings")]
        public async Task<IActionResult> GetSettingsByAppSlugAndIdentifierSlug(GetSettingsByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.GetSettingsByAppSlugAndIdentifierSlugAsync(
                new GetSettingsByAppAndIdentifierInput
                {
                    AppIdOrSlug = request.AppIdOrAppSlug,
                    IdentifierIdOrSlug = request.IdentifierIdOrSlug
                }, cancellationToken);

            return result.ToAction();
        }


        [HttpPut("{AppId}/identifiers/{IdentifierId}/sort-order")]
        public async Task<IActionResult> UpdateAppIdentifierMappingSortOrder(UpdateAppIdentifierMappingSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appIdentifierMappingsService.UpdateAppIdentifierMappingSortOrderAsync(new UpdateAppIdentifierMappingSortOrderInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Ascent = request.Body.Ascent,
                RowVersion = request.Body.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}/grouped")]
        public async Task<IActionResult> GetGroupedAppDataByAppIdAndIdentifierId(GetGroupedAppDataByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppIdAndIdentifierIdAsync(new GetGroupedAppDataByAppAndIdentifierInput { AppIdOrSlug = request.AppIdOrSlug, IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{AppIdOrSlug}/identifiers/{IdentifierIdOrSlug}/grouped")]
        public async Task<IActionResult> GetGroupedAppDataByAppSlugAndIdentifierSlug(GetGroupedAppDataByAppAndIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appsService.GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(new GetGroupedAppDataByAppAndIdentifierInput { AppIdOrSlug = request.AppIdOrSlug, IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }


        [HttpGet("{AppId}/settings/data")]
        public async Task<IActionResult> GetSettingsData(GetSettingsDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.GetSettingsDataAsync(new GetSettingsDataInput
            {
                AppId = request.AppId,
                IdentifierId = request.IdentifierId,
                Ids = request.Ids
            }, cancellationToken);

            return result.ToAction();
        }
    }
}