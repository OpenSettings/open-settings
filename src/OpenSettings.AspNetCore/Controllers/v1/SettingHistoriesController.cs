using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/setting-histories")]
    public class SettingHistoriesController : ControllerBase
    {
        private readonly ISettingHistoriesService _settingHistoriesService;

        public SettingHistoriesController(ISettingHistoriesService settingHistoriesService)
        {
            _settingHistoriesService = settingHistoriesService;
        }

        [HttpGet("{HistoryId}/data")]
        public async Task<IActionResult> GetSettingHistoryData(GetSettingHistoryDataRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _settingHistoriesService.GetSettingHistoryDataAsync(new GetSettingHistoryDataInput
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
                return ModelState.ToJsonAction();
            }

            var result = await _settingHistoriesService.GetSettingHistoryByIdAsync(new GetSettingHistoryInput
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
                return ModelState.ToJsonAction();
            }

            var result = await _settingHistoriesService.GetSettingHistoryBySlugAsync(new GetSettingHistoryInput
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
                return ModelState.ToJsonAction();
            }

            var result = await _settingHistoriesService.RestoreSettingHistoryAsync(new RestoreSettingHistoryInput
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