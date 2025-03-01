namespace OpenSettings.Models.Inputs
{
    public class GetTagsInput
    {
        public string SearchTerm { get; set; }

        public bool? HasMappings { get; set; }
    }
}