using System;

namespace OpenSettings.Domains.Sql.Entities
{
    internal class TenantSqlModel : EntityBase<Guid>
    {
        public string Name { get; set; }

        public string NameLowercase { get; set; }

        public string Slug { get; set; }

        public string DisplayName { get; set; }

        public string DisplayNameLowercase { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }
    }
}