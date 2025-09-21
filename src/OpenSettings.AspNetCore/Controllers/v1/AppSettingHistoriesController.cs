using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AppSettingHistoriesController : ControllerBase
    {
        private readonly ISettingHistoryService _settingHistoryService;

        public AppSettingHistoriesController(ISettingHistoryService settingHistoryService)
        {
            _settingHistoryService = settingHistoryService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryData)]
        public async Task<IActionResult> GetAppSettingHistoryData(GetAppSettingHistoryDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetAppSettingHistoryDataAsync(new GetAppSettingHistoryDataInput
            {
                AppSettingHistoryId = request.AppSettingHistoryId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryById)]
        public async Task<IActionResult> GetAppSettingHistoryById(GetAppSettingHistoryByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetAppSettingHistoryByIdAsync(new GetAppSettingHistoryInput
            {
                AppHistoryIdOrSlug = request.AppSettingHistoryId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryBySlug)]
        public async Task<IActionResult> GetAppSettingHistoryBySlug(GetAppSettingHistoryBySlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetAppSettingHistoryBySlugAsync(new GetAppSettingHistoryInput
            {
                AppHistoryIdOrSlug = request.AppSettingHistorySlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.RestoreAppSettingHistory)]
        public async Task<IActionResult> RestoreAppSettingHistory(RestoreSettingHistoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.RestoreAppSettingHistoryAsync(new RestoreAppSettingHistoryInput
            {
                AppSettingHistoryId = request.AppSettingHistoryId,
                HistoryRowVersion = request.Body.HistoryRowVersion,
                SettingRowVersion = request.Body.SettingRowVersion,
                UserId = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }
    }
}