using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace OpenSettings.Models
{
    public class License
    {
        private License() { }

        [JsonConstructor]
        public License(string holder, string referenceId, HashSet<string> features, DateTime? expiryDate, LicenseEdition? edition, DateTime? issuedAt, DateTime? notBefore)
        {
            Holder = holder;
            ReferenceId = referenceId;
            Features = features ?? new HashSet<string>();
            ExpiryDate = expiryDate;
            Edition = edition;
            IsExpired = DateTime.UtcNow > ExpiryDate;
            IssuedAt = issuedAt;
            NotBefore = notBefore;

            CheckValidation(); 
        }

        public License(ClaimsIdentity claimsIdentity) : this(new ClaimsPrincipal(claimsIdentity)) { }

        public License(ClaimsPrincipal claimsPrincipal)
        {
            ClaimsPrincipal = claimsPrincipal;

            Holder = claimsPrincipal.FindFirstValue("holder");
            ReferenceId = claimsPrincipal.FindFirstValue("referenceId");
            Features = new HashSet<string>(claimsPrincipal.FindAll("feature").Select(c => c.Value));
            ExpiryDate = GetDate("exp", claimsPrincipal);
            Edition = GetEdition(claimsPrincipal);
            IsExpired = DateTime.UtcNow > ExpiryDate;
            IssuedAt = GetDate("iat", claimsPrincipal) ?? DateTime.UtcNow;
            NotBefore = GetDate("nbf", claimsPrincipal) ?? DateTime.UtcNow;

            CheckValidation();
        }

        public void CheckValidation()
        {
            if (IsExpired)
            {
                FailureReasons.Add(LicenseFailureReason.Expired);
            }

            if(Edition == null)
            {
                FailureReasons.Add(LicenseFailureReason.EditionNotFound);
                Edition = LicenseEdition.Community;
            }
        }

        public string Holder { get; private set; }

        public string ReferenceId { get; }

        public HashSet<string> Features { get; }

        [JsonIgnore]
        private ClaimsPrincipal ClaimsPrincipal { get; }

        /// <summary>
        /// Gets the expiry date of the license. If the license does not expire, this property is <c>null</c>.
        /// </summary>
        public DateTime? ExpiryDate { get; }

        public LicenseEdition? Edition { get; private set; }

        [JsonIgnore]
        public bool IsExpired { get; }

        public DateTime? IssuedAt { get; }

        public DateTime? NotBefore { get; }

        internal bool IsFaulted => FailureReasons.Count > 0;

        internal List<LicenseFailureReason> FailureReasons { get; set; } = new List<LicenseFailureReason>();

        private static DateTime? GetDate(string claimType, ClaimsPrincipal claimsPrincipal)
        {
            var exp = claimsPrincipal.FindFirstValue(claimType);

            if (exp == null)
            {
                return null;
            }

            if (!long.TryParse(exp, out var expiration))
            {
                return null;
            }

            return DateTimeOffset.FromUnixTimeSeconds(expiration).UtcDateTime;
        }

        private static LicenseEdition? GetEdition(ClaimsPrincipal claimsPrincipal)
        {
            var edition = claimsPrincipal.FindFirstValue("edition")?.ToLowerInvariant();

            switch (edition)
            {
                case "community edition":
                case "community":
                case "comm":
                    return LicenseEdition.Community;

                case "personal edition":
                case "personal":
                case "per":
                    return LicenseEdition.Personal;

                case "professional edition":
                case "professional":
                case "pro":
                    return LicenseEdition.Professional;

                case "trial edition":
                case "trial":
                case "trl":
                    return LicenseEdition.Trial;

                case "enterprise edition":
                case "enterprise":
                case "ent":
                    return LicenseEdition.Enterprise;

                default:
                    return null;
            }
        }

        internal static License Community => new License
        {
            Edition = LicenseEdition.Community
        };
    }
}