using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppTagMappingSqlService : IAppTagMappingsSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public AppTagMappingSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}