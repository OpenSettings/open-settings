using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("DataProtectionKeys")]
    public class DataProtectionKey : EntityBase<int>
    {
        public Guid KeyId { get; set; }

        /// <summary>
        /// The master key which is an unencrypted form.
        /// </summary>
        public string MasterKey { get; set; }

        /// <summary>
        /// The friendly name of the <see cref="DataProtectionKey"/>.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The XML representation of the <see cref="DataProtectionKey"/>.
        /// </summary>
        public string Xml { get; set; }

        public string EncryptionAlgorithm { get; set; }

        public string ValidationAlgorithm { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}