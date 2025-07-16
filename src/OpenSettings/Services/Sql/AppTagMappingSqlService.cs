using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppTagMappingSqlService : IAppTagMappingSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public AppTagMappingSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}