using OpenSettings.Domains.Sql.Entities;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedLicensesResponseLicense
    {
        public GetPaginatedLicensesResponseLicense(LicenseSqlModel license)
        {
            Id = license.Id;
            ReferenceId = license.ReferenceId;
            Features = license.Features ?? Array.Empty<string>();
            ExpiryDate = license.ExpiryDate;
            IsExpired = license.IsExpired;
            IsRevoked = license.IsRevoked;
            RevokedOn = license.RevokedOn;
            Key = license.Key;
            Holder = license.Holder;
            Edition = license.Edition;
            CreatedOn = license.CreatedOn;
            UpdatedOn = license.UpdatedOn;
        }

        public int Id { get; set; }

        public string ReferenceId { get; set; }

        public string[] Features { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime? RevokedOn { get; set; }

        public string Key { get; set; }

        public string Holder { get; set; }

        public LicenseEdition Edition { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}