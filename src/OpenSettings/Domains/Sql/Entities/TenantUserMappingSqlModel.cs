using System;

namespace OpenSettings.Domains.Sql.Entities
{
    public class TenantUserMappingSqlModel : EntityBase<Guid>
    {
        public bool IsActive { get; set; }

        public Guid TenantId { get; set; }

        public virtual TenantSqlModel Tenant { get; set; }

        public Guid UserId { get; set; }

        public virtual UserSqlModel User { get; set; }
    }
}