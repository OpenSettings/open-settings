using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Models.Inputs
{
    public class GetSettingByIdInput
    {
        public GetSettingByIdInput(string settingId, string excludes)
        {
            SettingId = settingId;
            Excludes = string.IsNullOrWhiteSpace(excludes)
                ? new HashSet<string>()
                : new HashSet<string>(excludes.Split(Constants.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim().ToLowerInvariant()).Where(e => e != string.Empty));
        }

        public string SettingId { get; }

        public HashSet<string> Excludes { get; }
    }
}