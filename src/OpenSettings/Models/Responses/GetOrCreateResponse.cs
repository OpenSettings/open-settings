namespace OpenSettings.Models.Responses
{
    public class GetOrCreateResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public bool IsNewlyCreated { get; set; }
    }
}