using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenSettings.Domains.Sql.Configurations.Utility
{
    internal static class EfValueComparers
    {
        public static readonly ValueComparer<Dictionary<string, object>> ObjectDictionaryComparer =
            new ValueComparer<Dictionary<string, object>>(
                (d1, d2) => JsonSerializer.Serialize(d1, (JsonSerializerOptions)null) ==
                            JsonSerializer.Serialize(d2, (JsonSerializerOptions)null),
                d => JsonSerializer.Serialize(d, (JsonSerializerOptions)null).GetHashCode(),
                d => new Dictionary<string, object>());

        public static readonly ValueComparer<List<string>> ListComparer =
            new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c == null ? new List<string>() : c.ToList()
            );

        public static readonly ValueComparer<List<ReloadStrategy>> ListReloadStrategyComparer =
            new ValueComparer<List<ReloadStrategy>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c == null ? new List<ReloadStrategy>() : c.ToList()
            );

        public static readonly ValueComparer<string[]> ArrayStringComparer =
            new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c == null ? Array.Empty<string>() : c.ToArray()
            );
    }
}