namespace OpenSettings.AspNetCore.Models.Requests
{
    public class AuthenticatedResponse
    {
        public bool IsAuthenticated { get; set; }

        public string AccessToken { get; set; }
    }
}