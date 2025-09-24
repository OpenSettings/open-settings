using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSettings.Helpers
{
    internal static class RouteHelper
    {
        public static string Build(string template,
            string[] values = null,
            params (string key, object value)[] query)
        {
            Dictionary<string, string> dictionary;

            if (query?.Length > 0)
            {
                dictionary = new Dictionary<string, string>(query.Length, StringComparer.OrdinalIgnoreCase);

                foreach (var (key, value) in query)
                {
                    dictionary[key] = value?.ToString();
                }
            }
            else
            {
                dictionary = null;
            }

            return Build(template, values, dictionary);
        }

        public static string Build(string template,
            string[] values = null,
            Dictionary<string, string> query = null)
        {
            values = values ?? Array.Empty<string>();

            var sb = new StringBuilder(template.Length + 32);

            var count = 0;

            for (var i = 0; i < template.Length; i++)
            {
                var c = template[i];

                if (c == '{')
                {
                    var j = template.IndexOf('}', i + 1);

                    if (j < 0)
                    {
                        throw new ArgumentException("Unclosed token in template.");
                    }

                    if (values.Length - count == 0)
                    {
                        var key = template.AsSpan(i + 1, j - i - 1).ToString();

                        throw new ArgumentException($"Missing route value for '{key}'.");
                    }


                    sb.Append(Uri.EscapeDataString(values[count]));
                    count++;

                    i = j;
                }
                else
                {
                    sb.Append(c);
                }
            }

            if (query?.Count > 0)
            {
                var first = true;

                foreach (var kv in query)
                {
                    if (kv.Value is null)
                    {
                        continue;
                    }

                    sb.Append(first ? '?' : '&'); first = false;
                    sb.Append(Uri.EscapeDataString(kv.Key)).Append('=').Append(Uri.EscapeDataString(kv.Value));
                }
            }

            return sb.ToString();
        }
    }
}
