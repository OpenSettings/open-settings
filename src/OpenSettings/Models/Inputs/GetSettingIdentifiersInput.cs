namespace OpenSettings.Models.Inputs
{
    public class GetIdentifiersInput
    {
        public string SearchTerm { get; set; }

        public string AppId { get; set; }

        public bool IsAppMapped { get; set; }
    }
}