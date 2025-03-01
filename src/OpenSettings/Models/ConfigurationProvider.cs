using Ogu.Compressions.Abstractions;
using OpenSettings.Configurations;
using System.IO.Compression;

namespace OpenSettings.Models
{
    public class ConfigurationProvider
    {
        public RedisConfiguration Redis { get; set; } = new RedisConfiguration();

        public CompressionType CompressionType { get; set; } = CompressionType.None;

        public CompressionLevel CompressionLevel { get; set; } = CompressionLevel.Fastest;
    }
}