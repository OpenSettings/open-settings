using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppInput
    {
        public string AppId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? DeletedById { get; set; }
    }
}