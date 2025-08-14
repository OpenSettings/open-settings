using Microsoft.AspNetCore.Http;
using OpenSettings.Models;
using System;
using System.Net.Http.Headers;

namespace OpenSettings.AspNetCore.Extensions
{
    internal static class HeaderDictionaryExtensions
    {
        internal static string GetPackVersionHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.PackVersion, out var value) ? value : null;
        }
      
        internal static CallerType GetCallerTypeHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.CallerType,
                       out var callerTypeAsString) &&
                   TryGetEnumValue<CallerType>(OpenSettingsDefaults.Types.CallerType, callerTypeAsString, out var callerType)
                ? callerType
                : CallerType.Unset;
        }

        internal static AuthType GetAuthTypeHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.AuthType, out var authTypeAsString) &&
                   TryGetEnumValue<AuthType>(OpenSettingsDefaults.Types.LoginType, authTypeAsString, out var authType)
                ? authType
                : AuthType.Unset;
        }

        internal static AuthMethod GetAuthMethodHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.AuthMethod, out var authMethodAsString) &&
                   TryGetEnumValue<AuthMethod>(OpenSettingsDefaults.Types.LoginType, authMethodAsString, out var authMethod)
                ? authMethod
                : AuthMethod.Unset;
        }

        internal static Guid? GetClientIdHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.ClientId,
                       out var clientIdAsString) &&
                   Guid.TryParse(clientIdAsString, out var clientId)
                ? (Guid?)clientId
                : null;
        }

        internal static AuthenticationHeaderValue GetAuthenticationHeaderValueFromAuthorizationHeader(this IHeaderDictionary headerDictionary)
        {
            return TryGetHeaderValue(headerDictionary, OpenSettingsDefaults.Headers.Authorization, out var authorizationHeaderValueAsString) && 
                   AuthenticationHeaderValue.TryParse(authorizationHeaderValueAsString, out var authorizationHeaderValue) ? authorizationHeaderValue : null;
        }

        private static bool TryGetHeaderValue(IHeaderDictionary headerDictionary, string key, out string value)
        {
            if (!headerDictionary.TryGetValue(key, out var stringValues))
            {
                value = null;

                return false;
            }

            value = stringValues;

            return !string.IsNullOrWhiteSpace(value);
        }

        private static bool TryGetEnumValue<T>(Type enumType, string value, out T result) where T : struct
        {
            if (
#if NETSTANDARD2_0
                Enum.TryParse(value, out T parseResult) &&
#else
                Enum.TryParse(enumType, value, ignoreCase: true, out var parseResult) &&
#endif
                Enum.IsDefined(enumType, parseResult))
            {
                result = (T)parseResult;

                return true;
            }

            result = default;

            return false;
        }
    }
}
