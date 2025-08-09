namespace OpenSettings.Models.Responses
{
    public class IsAuthenticatedResponse
    {
        public bool IsAuthenticated { get; set; }

        public string AccessToken { get; set; }
    }
}