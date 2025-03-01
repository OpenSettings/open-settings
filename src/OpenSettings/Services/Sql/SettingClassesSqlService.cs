using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class SettingClassesSqlService : ISettingClassesSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public SettingClassesSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}