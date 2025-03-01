using StackExchange.Redis;
using System.Text.Json;

namespace OpenSettings.Models
{
    public class RedisMessage
    {
        public RedisMessage(RedisMessageType messageType, string instanceDynamicId, object data)
        {
            MessageType = messageType;
            InstanceDynamicId = instanceDynamicId;
            Data = data;
        }

        public RedisMessageType MessageType { get; }

        public object Data { get; }

        public string InstanceDynamicId { get; }

        public static implicit operator RedisValue(RedisMessage message)
        {
            return new RedisValue(JsonSerializer.Serialize(message, JsonSerializerOptions.Default));
        }
    }
}