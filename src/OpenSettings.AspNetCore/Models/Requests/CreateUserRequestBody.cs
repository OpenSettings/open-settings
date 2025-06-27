namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateUserRequestBody
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}