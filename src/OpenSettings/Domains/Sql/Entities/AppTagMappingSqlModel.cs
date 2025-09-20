using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents an app-tag mapping entity.
    /// </summary>
    public class AppTagMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// The id of the associated app.
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// The app associated with this mapping.
        /// </summary>
        public virtual AppSqlModel App { get; set; }

        /// <summary>
        /// The id of the associated tag.
        /// </summary>
        public Guid AppTagId { get; set; }

        /// <summary>
        /// The tag associated with this mapping.
        /// </summary>
        public virtual AppTagSqlModel AppTag { get; set; }

        /// <summary>
        /// The id of the user who created this app-tag mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this app-tag mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}