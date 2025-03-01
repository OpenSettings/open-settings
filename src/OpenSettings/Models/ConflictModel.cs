using System;

namespace OpenSettings.Models
{
    public class ConflictModel
    {
        public string Id { get; set; }

        public byte[] CurrentRowVersion { get; set; } = Array.Empty<byte>();

        public byte[] ProposedRowVersion { get; set; } = Array.Empty<byte>();

        public bool Deleted { get; set; }
    }
}