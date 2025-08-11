namespace OpenSettings.Models.Responses
{
    public class GetAuthStatusResponse
    {
        public bool IsAuthenticated { get; set; }

        public string AccessToken { get; set; }
    }
}