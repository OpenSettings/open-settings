using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Models.Inputs
{
    public class GetSettingHistoriesInput
    {
        public GetSettingHistoriesInput(Guid appSettingId, string excludes)
        {
            AppSettingId = appSettingId;
            Excludes = string.IsNullOrWhiteSpace(excludes)
                ? new HashSet<string>()
                : new HashSet<string>(excludes.Split(OpenSettingsDefaults.Separators.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim().ToLowerInvariant()).Where(e => e != string.Empty));
        }

        public Guid AppSettingId { get; }

        public HashSet<string> Excludes { get; }
    }
}