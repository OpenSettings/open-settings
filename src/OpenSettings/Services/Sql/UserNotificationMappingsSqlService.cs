using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Services.Sql.Interfaces;

namespace OpenSettings.Services.Sql
{
    internal sealed class UserNotificationMappingsSqlService : IUserNotificationMappingsSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public UserNotificationMappingsSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }
    }
}