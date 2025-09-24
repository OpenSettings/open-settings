namespace OpenSettings.Models.Responses
{
    public class CopyAppSettingToResponseIdentifier
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int SortOrder { get; set; }

        public int AppMappingSortOrder { get; set; }
    }
}