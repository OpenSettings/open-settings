using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppSettingClassSqlService : ISettingClassSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public AppSettingClassSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}