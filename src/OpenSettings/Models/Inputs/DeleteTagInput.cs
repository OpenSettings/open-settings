using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteTagInput
    {
        public string TagId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}