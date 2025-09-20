using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppTagInput
    {
        public Guid AppTagId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}