namespace OpenSettings.Models.Responses
{
    public class GetAppResponseGroup
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public static GetAppResponseGroup UngroupedApps { get; } = new GetAppResponseGroup
        {
            Id = "-1",
            Name = "Ungrouped apps",
            SortOrder = 0
        };
    }
}