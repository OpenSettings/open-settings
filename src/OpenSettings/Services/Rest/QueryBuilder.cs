using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Services.Rest
{
    public class QueryBuilder
    {
        private const string Comma = ",";
        private const string And = "&";
        private const char SlashChar = '/';
        private const string UniversalFormat = "o";

        private readonly IDictionary<string, object> _dictionary;

        public QueryBuilder()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public QueryBuilder(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            _dictionary = new Dictionary<string,object> { { key, value}};
        }

        public QueryBuilder(IDictionary<string, object> dictionary)
        {
            _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public QueryBuilder Append(string key, object value)
        {
            _dictionary.Add(key, value);

            return this;
        }

        private string Build()
        {
            return _dictionary.Count > 0
                ? $"?{string.Join(And, _dictionary.Select(kvp => $"{kvp.Key}={ConvertObjectToQueryString(kvp.Value)}"))}"
                : string.Empty;
        }

        public string ToString(string uri)
        {
            return $"{uri.TrimEnd(SlashChar)}{Build()}";
        }

        public override string ToString()
        {
            return Build();
        }

        private static string ConvertObjectToQueryString(object value)
        {
            switch (value)
            {
                case null:

                    return string.Empty;

                case bool booleanValue:

                    return booleanValue.ToString();

                case byte[] byteArray:

                    return Uri.EscapeDataString(Convert.ToBase64String(byteArray));

                case IEnumerable<object> collection:

                    return string.Join(Comma, collection.Where(i => i != null).Select(item =>
                    {
                        var objectToString = item.ToString();

                        return objectToString == null ? string.Empty : Uri.EscapeDataString(objectToString);
                    }));

                case DateTime dateTime:

                    return Uri.EscapeDataString(dateTime.ToString(UniversalFormat));

                default:

                    var valueToString = value.ToString();
                    return valueToString == null ? string.Empty : Uri.EscapeDataString(valueToString);
            }
        }
    }
}