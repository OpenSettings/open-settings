using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppGroupInput
    {
        public Guid AppGroupId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}