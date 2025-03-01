using Ogu.Compressions.Abstractions;
using System;
using System.IO.Compression;

namespace OpenSettings.Models.Responses
{
    public class GetSettingResponse
    {
        public CompressionType CompressionType { get; set; }

        public CompressionLevel CompressionLevel { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();

        public bool DataRestored { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string Version { get; set; }

        public string IdentifierId { get; set; }

        public string AppId { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}