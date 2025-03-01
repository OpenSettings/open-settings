namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppsResponseAppGroup
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public static GetGroupedAppsResponseAppGroup UngroupedApps { get; } = new GetGroupedAppsResponseAppGroup
        {
            Id = GetAppResponseGroup.UngroupedApps.Id,
            Name = GetAppResponseGroup.UngroupedApps.Name,
            SortOrder = GetAppResponseGroup.UngroupedApps.SortOrder
        };
    }
}