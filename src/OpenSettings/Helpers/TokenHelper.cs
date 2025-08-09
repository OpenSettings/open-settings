using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace OpenSettings.Helpers
{
    /// <summary>
    /// Provides helper methods for token operations.
    /// </summary>
    internal static class TokenHelper
    {
        /// <summary>
        /// Checks if the provided JWT security token has expired based on its ValidTo property.
        /// </summary>
        /// <param name="securityToken">The JwtSecurityToken.</param>
        /// <param name="referenceDate">An optional reference date to compare against. If null, the current UTC time is used.</param>
        /// <returns></returns>
        public static bool IsTokenExpired(JwtSecurityToken securityToken, DateTime? referenceDate = null)
        {
            return securityToken.ValidTo < (referenceDate ?? DateTime.UtcNow);
        }

        /// <summary>
        /// Checks if the expiration time of the provided JWT security token is less than the specified time span.
        /// </summary>
        /// <param name="securityToken">The JwtSecurityToken.</param>
        /// <param name="timeSpan">The time span.</param>
        /// <param name="referenceDate">An optional reference date to compare against. If null, the current UTC time is used.</param>
        /// <returns>A boolean value whether token is expired or not.</returns>
        public static bool IsTokenExpirationTimeLessThan(JwtSecurityToken securityToken, TimeSpan timeSpan, DateTime? referenceDate = null)
        {
            return securityToken.ValidTo - (referenceDate ?? DateTime.UtcNow) < timeSpan;
        }

        /// <summary>
        /// Checks if the expiration time of the provided HTTP-date formatted string is less than the specified time span.
        /// </summary>
        /// <param name="expires">Expiry time in RFC1123 format e.g. "Thu, 26 Jun 2025 14:14:56 GMT".</param>
        /// <param name="timeSpan">The time span.</param>
        /// <param name="referenceDate">An optional reference date to compare against. If null, the current UTC time is used.</param>
        /// <returns>A boolean value whether token is expired or not.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static bool IsTokenExpirationTimeLessThan(string expires, TimeSpan timeSpan, DateTimeOffset? referenceDate = null)
        {
            return Helper.GetExpiryTimeOffset(expires) - (referenceDate ?? DateTimeOffset.UtcNow) < timeSpan;
        }


        public static byte[] HmacSha256(byte[] key, string token)
        {
            using (var h = new HMACSHA256(key))
            {
                return h.ComputeHash(System.Text.Encoding.UTF8.GetBytes(token));
            }
        }

        public static string ToHexString(byte[] b) => BitConverter.ToString(b).Replace("-", "").ToLowerInvariant();
    }
}