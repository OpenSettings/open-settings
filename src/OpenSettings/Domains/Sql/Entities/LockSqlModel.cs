using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a lock entity.
    /// </summary>
    [Table("Locks")]
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
        public DateTime ExpiryTime { get; set; }
    }
}