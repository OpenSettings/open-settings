using Microsoft.EntityFrameworkCore;

namespace OpenSettings.Domains.Sql.Configurations.Utility
{
    internal interface IEntityTypeConfigurationAdapter
    {
        void Apply(ModelBuilder modelBuilder);
    }
}