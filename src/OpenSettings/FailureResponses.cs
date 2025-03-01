using Ogu.Response.Json;
using OpenSettings.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace OpenSettings
{
    internal static class FailureResponses
    {
        internal static IJsonResponse<T> Conflict<T>(string id, byte[] currentRowVersion, byte[] proposedRowVersion, bool isDeleted)
        {
            var jsonResponse = HttpStatusCode.Conflict.ToFailureJsonResponse<T>("Concurrency Conflict", "The data has been modified by someone else.");

            jsonResponse.Extras["Conflicts"] = new ConcurrencyConflict
            {
                {
                    id, new ConcurrencyConflictInfo
                    {
                        Deleted = isDeleted,
                        Properties = new Dictionary<string, ConcurrencyConflictValue>
                        {
                            { "RowVersion", new ConcurrencyConflictValue(currentRowVersion, proposedRowVersion) }
                        }
                    }
                }
            };

            return jsonResponse;
        }

        internal static IJsonResponse Conflict(string id, byte[] currentRowVersion, byte[] proposedRowVersion, bool isDeleted)
        {
            var jsonResponse = HttpStatusCode.Conflict.ToFailureJsonResponse("Concurrency Conflict", "The data has been modified by someone else.");

            jsonResponse.Extras["Conflicts"] = new ConcurrencyConflict
            {
                {
                    id, new ConcurrencyConflictInfo
                    {
                        Deleted = isDeleted,
                        Properties = new Dictionary<string, ConcurrencyConflictValue>
                        {
                            { "RowVersion", new ConcurrencyConflictValue(currentRowVersion, proposedRowVersion) }
                        }
                    }
                }
            };

            return jsonResponse;
        }

        internal static IJsonResponse<T> Conflict<T>(params ConflictModel[] conflicts)
        {
            var jsonResponse = HttpStatusCode.Conflict.ToFailureJsonResponse<T>("Concurrency Conflict", "The data has been modified by someone else.");

            var concurrencyConflict = conflicts.ToDictionary(c => c.Id, c => new ConcurrencyConflictInfo
            {
                Deleted = c.Deleted,
                Properties = new Dictionary<string, ConcurrencyConflictValue>
                {
                    { "RowVersion", new ConcurrencyConflictValue(c.CurrentRowVersion, c.ProposedRowVersion) }
                }
            });

            jsonResponse.Extras["Conflicts"] = concurrencyConflict;

            return jsonResponse;
        }

        internal static IJsonResponse Conflict(params ConflictModel[] conflicts)
        {
            var jsonResponse = HttpStatusCode.Conflict.ToFailureJsonResponse("Concurrency Conflict", "The data has been modified by someone else.");

            var concurrencyConflict = conflicts.ToDictionary(c => c.Id, c => new ConcurrencyConflictInfo
            {
                Deleted = c.Deleted,
                Properties = new Dictionary<string, ConcurrencyConflictValue>
                {
                    { "RowVersion", new ConcurrencyConflictValue(c.CurrentRowVersion, c.ProposedRowVersion) }
                }
            });

            jsonResponse.Extras["Conflicts"] = concurrencyConflict;

            return jsonResponse;
        }
    }
}