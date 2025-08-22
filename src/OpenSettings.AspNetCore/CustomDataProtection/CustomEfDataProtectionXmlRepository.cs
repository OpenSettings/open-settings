using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace OpenSettings.AspNetCore.CustomDataProtection
{
    public class CustomEfDataProtectionXmlRepository : IXmlRepository
    {
        public virtual IReadOnlyCollection<XElement> GetAllElements()
        {
            return GetAllElementsCore().ToArray();

            IEnumerable<XElement> GetAllElementsCore()
            {
                using (var context = OpenSettingsDbContext.GetInstance(OpenSettingsDefaults.Caches.OpenSettingsConfiguration.Provider, OpenSettingsDefaults.Caches.OpenSettingsConfiguration.LoggerFactory))
                {
                    foreach (var key in context.DataProtectionKeys.AsNoTracking())
                    {
                        if (!string.IsNullOrEmpty(key.Xml))
                        {
                            yield return XElement.Parse(key.Xml);
                        }
                    }
                }
            }
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            using (var context = OpenSettingsDbContext.GetInstance(OpenSettingsDefaults.Caches.OpenSettingsConfiguration.Provider, OpenSettingsDefaults.Caches.OpenSettingsConfiguration.LoggerFactory))
            {
                var keyId = element.Attribute("id")?.Value;

                var newKey = new DataProtectionKey
                {
                    KeyId = keyId == null ? Guid.Empty : Guid.Parse(keyId),
                    MasterKey = element.Descendants("masterKey").Elements("value").FirstOrDefault()?.Value,
                    FriendlyName = friendlyName,
                    Xml = element.ToString(SaveOptions.DisableFormatting),
                    EncryptionAlgorithm = element.Descendants("encryption").FirstOrDefault()?.Attribute("algorithm")?.Value,
                    ValidationAlgorithm = element.Descendants("validation").FirstOrDefault()?.Attribute("algorithm")?.Value,
                    CreatedOn = DateTime.Parse(element.Element("creationDate")?.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal),
                    ActivationDate = DateTime.Parse(element.Element("activationDate")?.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal),
                    ExpiryDate = DateTime.Parse(element.Element("expirationDate")?.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal)
                };

                var entry = context.DataProtectionKeys.Add(newKey);

                context.SaveChanges();

                entry.State = EntityState.Detached;
            }
        }
    }
}