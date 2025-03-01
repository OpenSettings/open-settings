using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteIdentifierInput
    {
        public string IdentifierId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}