using System;
using System.Collections.Generic;

namespace OpenSettings.Domains.Sql.Entities
{
    public class TenantSqlModel : EntityBase<Guid>
    {
        public string Name { get; set; }

        public string NameLowercase { get; set; }

        public string Slug { get; set; }

        public string DisplayName { get; set; }

        public string DisplayNameLowercase { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// The id of the user who created this tag.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this tag.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The id of the user who last updated this tag.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// The user who last updated this app group.
        /// </summary>
        public virtual UserSqlModel UpdatedBy { get; set; }

        public virtual ICollection<TenantUserMappingSqlModel> TenantUserMappings { get; set; } = new List<TenantUserMappingSqlModel>();
    }
}