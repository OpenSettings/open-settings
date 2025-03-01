using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using Ogu.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/settings")]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;
        private readonly ISettingHistoriesService _settingHistoriesService;

        public SettingsController(ISettingsService settingsService, ISettingHistoriesService settingHistoriesService)
        {
            _settingsService = settingsService;
            _settingHistoriesService = settingHistoriesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSetting(CreateSettingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.CreateSettingAsync(new CreateSettingInput
            {
                AppId = request.Body.AppId,
                IdentifierId = request.Body.IdentifierId,
                ComputedIdentifier = request.Body.ComputedIdentifier,
                ClassNamespace = request.Body.Class.Namespace,
                ClassName = request.Body.Class.Name,
                ClassFullName = request.Body.Class.FullName,
                Data = request.Body.Data,
                StoreInSeparateFile = request.Body.StoreInSeparateFile,
                IgnoreOnFileChange = request.Body.IgnoreOnFileChange,
                RegistrationMode = request.Body.RegistrationMode,
                CreatedById = User.GetUserId(),
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("latest-updates")]
        [Authorize(AuthenticationSchemes = OpenSettings.Constants.OpenSettingsBasicAuthScheme)]
        public async Task<IActionResult> GetSettingsLastUpdatedComputedIdentifiers([FromBody] GetSettingsLastUpdatedComputedIdentifiersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.GetSettingsLastUpdatedComputedIdentifiersAsync(new GetSettingsLastUpdatedComputedIdentifiersInput
            {
                ClientId = request.ClientId,
                IdentifierName = request.IdentifierName,
                LastUpdatedOn = request.LastUpdatedOn
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{SettingId}")]
        public async Task<IActionResult> GetSettingById(GetSettingByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.GetSettingByIdAsync(new GetSettingByIdInput(request.SettingId, request.Excludes), cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{SettingId}")]
        public async Task<IActionResult> UpdateSetting(UpdateSettingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            if (request.Body.ComputedIdentifier == Guid.Empty)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.ComputedIdentifierMustNotEmpty).ToAction();
            }

            var result = await _settingsService.UpdateSettingAsync(new UpdateSettingInput
            {
                SettingId = request.SettingId,
                ComputedIdentifier = request.Body.ComputedIdentifier,
                DataValidationDisabled = request.Body.DataValidationDisabled,
                StoreInSeparateFile = request.Body.StoreInSeparateFile,
                IgnoreOnFileChange = request.Body.IgnoreOnFileChange,
                RegistrationMode = request.Body.RegistrationMode,
                SettingRowVersion = request.Body.RowVersion,
                ClassNamespace = request.Body.Class.Namespace,
                ClassName = request.Body.Class.Name,
                ClassFullName = request.Body.Class.FullName,
                ClassRowVersion = request.Body.Class.RowVersion,
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{SettingId}")]
        public async Task<IActionResult> DeleteSetting(DeleteSettingRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(ModelState).ToAction();
            }

            var result = await _settingsService.DeleteSettingAsync(new DeleteSettingInput
            {
                SettingId = request.SettingId,
                RowVersion = request.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{SettingId}/histories")]
        public async Task<IActionResult> GetSettingHistories(GetSettingHistoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingHistoriesService.GetSettingHistoriesAsync(new GetSettingHistoriesInput(request.SettingId, request.Excludes), cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{SettingId}/copy")]
        public async Task<IActionResult> CopySettingTo(CopySettingToRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingsService.CopySettingToAsync(new CopySettingToInput
            {
                SettingId = request.SettingId,
                TargetAppId = request.Body.TargetAppId,
                IdentifierId = request.Body.Identifier.Id,
                IdentifierName = request.Body.Identifier.Name,
                UserId = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{SettingId}/data")]
        public async Task<IActionResult> GetSettingData(GetSettingDataRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _settingsService.GetSettingDataAsync(new GetSettingDataInput
            {
                SettingId = request.SettingId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{SettingId}/data")]
        public async Task<IActionResult> UpdateSettingData(UpdateSettingDataRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _settingsService.UpdateSettingDataAsync(new UpdateSettingDataInput
            {
                SettingId = request.SettingId,
                Data = request.Body.Data,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }
    }
}