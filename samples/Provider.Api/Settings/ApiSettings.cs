using OpenSettings.Attributes;
using OpenSettings.Services.Interfaces;
using System;
using OpenSettings.Models;

namespace Provider.Api.Settings
{
    [RegistrationMode(RegistrationMode.Singleton)]
    public class ApiSettings : ISettings
    {
        public string ConnectionString { get; set; } = "Data Source=MyDb.db";
        public int Duration { get; set; } = 10;
        public DateTime ServiceTime1 { get; set; } = DateTime.Now;
    }

    public class KullaniciAyarlari : ISettings
    {
        public bool AktifOlmadigindaKullaniciyiAtEtkinMi { get; set; } = true;

        public string VeritabaniBaglantiBilgisi { get; set; }
    }
}

namespace Gamzecan
{
    //public class Lokumcan : ISettings
    //{
    //    public string DatabaseBaglantiBilgisi { get; set; } = "Prod:1235";
    //}
}