using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataResponseSettingClass
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string FullName { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}