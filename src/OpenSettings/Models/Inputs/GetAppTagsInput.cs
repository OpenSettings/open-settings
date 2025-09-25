namespace OpenSettings.Models.Inputs
{
    public class GetAppTagsInput
    {
        public string SearchTerm { get; set; }

        public bool? HasMappings { get; set; }
    }
}