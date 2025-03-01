using System;
using System.Collections.Generic;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class FetchAppDataRequestBody
    {
        public HashSet<Guid> ComputedIdentifiers { get; set; } = new HashSet<Guid>();

        public bool? StoreInSeparateFile { get; set; }
    }
}