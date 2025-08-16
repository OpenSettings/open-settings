namespace OpenSettings.Models.Inputs
{
    public class GetMeInput
    {
        public string Uuid { get; set; }

        public string ClaimTypes { get; set; }

        public GetMeInputIncludes Includes { get; set; }
    }
}