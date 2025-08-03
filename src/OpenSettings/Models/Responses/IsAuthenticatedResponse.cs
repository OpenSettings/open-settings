namespace OpenSettings.AspNetCore.Models.Requests
{
    public class IsAuthenticatedResponse
    {
        public bool IsAuthenticated { get; set; }

        public string AccessToken { get; set; }
    }
}