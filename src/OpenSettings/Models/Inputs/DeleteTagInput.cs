using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppTagInput
    {
        public string AppTagId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}