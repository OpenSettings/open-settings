using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class UserNotificationMappingSqlService : IUserNotificationMappingsSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public UserNotificationMappingSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}