using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class SettingClassSqlService : ISettingClassSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public SettingClassSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}