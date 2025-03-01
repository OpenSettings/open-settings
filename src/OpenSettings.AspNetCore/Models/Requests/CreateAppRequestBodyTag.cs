namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppRequestBodyTag
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }
    }
}