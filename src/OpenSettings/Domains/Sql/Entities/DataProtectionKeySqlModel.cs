using System;

namespace OpenSettings.Domains.Sql.Entities
{
    public class DataProtectionKeySqlModel : EntityBase<int>
    {
        public Guid KeyId { get; set; }

        /// <summary>
        /// The master key which is an unencrypted form.
        /// </summary>
        public string MasterKey { get; set; }

        /// <summary>
        /// The friendly name of the <see cref="DataProtectionKeySqlModel"/>.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The XML representation of the <see cref="DataProtectionKeySqlModel"/>.
        /// </summary>
        public string Xml { get; set; }

        public string EncryptionAlgorithm { get; set; }

        public string ValidationAlgorithm { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}