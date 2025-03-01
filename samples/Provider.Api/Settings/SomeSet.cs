using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    public class SomeSet : ISettings
    {
        public string Dekan { get; set; } = "Ne";
        public string Varan { get; set; } = "Nasıl";
        public string Naran { get; set; } = "Kim";
    }
}

namespace SomeSome.Can
{
    public class KullaniciAyarlari : ISettings
    {
        public bool BokbBok { get; set; } = true;

        public string VeritabaniBaglantiBilgisi { get; set; }
    }
}