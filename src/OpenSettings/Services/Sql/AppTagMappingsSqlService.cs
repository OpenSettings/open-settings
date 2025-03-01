using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppTagMappingsSqlService : IAppTagMappingsSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public AppTagMappingsSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}