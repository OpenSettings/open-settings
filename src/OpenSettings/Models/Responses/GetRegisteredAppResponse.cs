namespace OpenSettings.Models.Responses
{
    public class GetRegisteredAppResponse
    {
        public string ClientName { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsClientIdUnique { get; set; }

        public bool IsClientSecretMatched { get; set; }
    }
}