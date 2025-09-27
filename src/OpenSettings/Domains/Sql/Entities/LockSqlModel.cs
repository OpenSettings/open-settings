using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a lock entity.
    /// </summary>
    public class LockSqlModel
    {
        /// <summary>
        /// The key of the lock.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The owner of the lock.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The expiry time of the lock.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        public Guid? TenantId { get; set; }

        public virtual TenantSqlModel Tenant { get; set; }
    }
}