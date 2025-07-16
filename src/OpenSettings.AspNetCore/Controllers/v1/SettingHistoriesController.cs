using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.SettingHistories)]
    public class SettingHistoriesController : ControllerBase
    {
        private readonly ISettingHistoryService _settingHistoryService;

        public SettingHistoriesController(ISettingHistoryService settingHistoryService)
        {
            _settingHistoryService = settingHistoryService;
        }

        [HttpGet("{HistoryId}/data")]
        public async Task<IActionResult> GetSettingHistoryData(GetSettingHistoryDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetSettingHistoryDataAsync(new GetSettingHistoryDataInput
            {
                HistoryId = request.HistoryId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{HistoryIdOrSlug}")]
        public async Task<IActionResult> GetSettingHistoryById(GetSettingHistoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetSettingHistoryByIdAsync(new GetSettingHistoryInput
            {
                HistoryIdOrSlug = request.HistoryIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{HistoryIdOrSlug}")]
        public async Task<IActionResult> GetSettingHistoryBySlug(GetSettingHistoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.GetSettingHistoryBySlugAsync(new GetSettingHistoryInput
            {
                HistoryIdOrSlug = request.HistoryIdOrSlug
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{HistoryId}/restore")]
        public async Task<IActionResult> RestoreSettingHistory(RestoreSettingHistoryRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _settingHistoryService.RestoreSettingHistoryAsync(new RestoreSettingHistoryInput
            {
                HistoryId = request.HistoryId,
                HistoryRowVersion = request.Body.HistoryRowVersion,
                SettingRowVersion = request.Body.SettingRowVersion,
                UserId = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }
    }
}