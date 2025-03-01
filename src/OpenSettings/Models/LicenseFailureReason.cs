namespace OpenSettings.Models
{
    internal enum LicenseFailureReason
    {
        EditionNotFound = 1,
        Expired = 2,
        RestException = 3,
        RestFailure = 4,
        SqlException = 5,
        Invalid = 6
    }
}