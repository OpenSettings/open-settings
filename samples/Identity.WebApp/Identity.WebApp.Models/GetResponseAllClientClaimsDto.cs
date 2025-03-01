namespace Ogu.Vehicle.IdentityServer.WebApp.Models
{
    public class GetResponseAllClientClaimsDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public TranslationDto Translation { get; set; }
    }
}