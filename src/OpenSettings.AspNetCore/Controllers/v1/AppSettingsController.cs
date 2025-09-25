using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AppSettingsController : ControllerBase
    {
        private readonly IAppSettingService _appSettingService;
        private readonly IAppSettingHistoryService _settingHistoryService;

        public AppSettingsController(IAppSettingService appSettingService, IAppSettingHistoryService settingHistoryService)
        {
            _appSettingService = appSettingService;
            _settingHistoryService = settingHistoryService;
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.CreateAppSetting)]
        public async Task<IActionResult> CreateAppSetting(CreateAppSettingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.CreateAppSettingAsync(new CreateAppSettingInput
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

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingsLastUpdatedComputedIdentifiers)]
        [Authorize(AuthenticationSchemes = OpenSettingsDefaults.AuthSchemes.Basic)]
        public async Task<IActionResult> GetAppSettingsLastUpdatedComputedIdentifiers([FromBody] GetSettingsLastUpdatedComputedIdentifiersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.GetAppSettingsLastUpdatedComputedIdentifiersAsync(new GetAppSettingsLastUpdatedComputedIdentifiersInput
            {
                ClientId = request.ClientId,
                IdentifierName = request.IdentifierName,
                LastUpdatedOn = request.LastUpdatedOn
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingById)]
        public async Task<IActionResult> GetAppSettingById(GetAppSettingByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.GetAppSettingByIdAsync(new GetAppSettingByIdInput(request.AppSettingId, request.Excludes), cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.UpdateAppSetting)]
        public async Task<IActionResult> UpdateAppSetting(UpdateAppSettingRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            if (request.Body.ComputedIdentifier == Guid.Empty)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.ComputedIdentifierMustNotEmpty).ToAction();
            }

            var result = await _appSettingService.UpdateAppSettingAsync(new UpdateAppSettingInput
            {
                AppSettingId = request.AppSettingId,
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

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.DeleteAppSetting)]
        public async Task<IActionResult> DeleteAppSetting(DeleteAppSettingRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(ModelState).ToAction();
            }

            var result = await _appSettingService.DeleteAppSettingAsync(new DeleteAppSettingInput
            {
                AppSettingId = request.AppSettingId,
                RowVersion = request.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingHistories)]
        public async Task<IActionResult> GetAppSettingHistories(GetSettingHistoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetAppSettingHistoriesAsync(new GetAppSettingHistoriesInput(request.AppSettingId, request.Excludes), cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.CopyAppSettingTo)]
        public async Task<IActionResult> CopyAppSettingTo(CopyAppSettingToRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appSettingService.CopyAppSettingToAsync(new CopyAppSettingToInput
            {
                AppSettingId = request.AppSettingId,
                TargetAppId = request.Body.TargetAppId,
                IdentifierId = request.Body.Identifier.Id,
                IdentifierName = request.Body.Identifier.Name,
                UserId = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingData)]
        public async Task<IActionResult> GetAppSettingData(GetSettingDataRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _appSettingService.GetAppSettingDataAsync(new GetAppSettingDataInput
            {
                AppSettingId = request.AppSettingId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.UpdateAppSettingData)]
        public async Task<IActionResult> UpdateAppSettingData(UpdateAppSettingDataRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _appSettingService.UpdateAppSettingDataAsync(new UpdateAppSettingDataInput
            {
                AppSettingId = request.AppSettingId,
                Data = request.Body.Data,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }
    }
}