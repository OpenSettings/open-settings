using System.ComponentModel;

namespace OpenSettings
{
    /// <summary>
    /// Defines error codes and their descriptions used throughout OpenSettings.
    /// Error codes are categorized into ranges for better organization.
    /// </summary>
    public enum Errors
    {
        // Validation Errors (40000-40099)

        [Description("Setting identifier must not be empty.")]
        IdentifierMustNotEmpty = 40000,

        [Description("Computed identifier must not be empty.")]
        ComputedIdentifierMustNotEmpty = 40001,

        [Description("Setting data does not match the expected setting class. You may disable validation in settings if needed.")]
        InvalidSettingData = 40002,

        [Description("No changes were made.")]
        NoChanges = 40003,

        [Description("Cannot move the item further up. It is already at the top of the list.")]
        MinSortOrderReached = 40004,

        [Description("Cannot move the item further down. It is already at the bottom of the list.")]
        MaxSortOrderReached = 40005,

        [Description("The sort order adjustment process was disrupted and is being reprocessed.")]
        SortOrderBeingReprocessed = 40006,

        [Description("Different user ids matched.")]
        UserNotMatched = 40007,

        [Description("Notification has expired")]
        NotificationExpired = 40008,

        [Description("License key is invalid.")]
        InvalidLicenseKey = 40009,

        [Description("License has expired.")]
        LicenseExpired = 40010,

        [Description("License has been revoked.")]
        LicenseRevoked = 40011,

        [Description("Reference id must not be empty.")]
        ReferenceIdMustNotEmpty = 40012,

        [Description("License edition could not be recognized.")]
        UnrecognizedLicenseEdition = 40013,

        [Description("Client name does not match the expected value.")]
        MismatchedClientName = 40014,

        [Description("Client id does not match the expected value.")]
        MismatchedClientId = 40015,

        // NotAuthorized Errors (40100-40199)

        [Description("The provided credentials are invalid.")]
        InvalidCredentials = 40100,


        // NotFound Errors (40400-40499)

        [Description("Setting identifier not found.")]
        IdentifierNotFound = 40400,

        [Description("Source setting identifier not found.")]
        SourceIdentifierNotFound = 40401,

        [Description("Target setting identifier not found.")]
        TargetIdentifierNotFound = 40402,

        [Description("History not found.")]
        HistoryNotFound = 40403,

        [Description("Setting not found.")]
        SettingNotFound = 40404,

        [Description("Group not found.")]
        GroupNotFound = 40405,

        [Description("Instance not found.")]
        InstanceNotFound = 40406,

        [Description("App not found.")]
        AppNotFound = 40407,

        [Description("Tag not found.")]
        TagNotFound = 40408,

        [Description("User not found.")]
        UserNotFound = 40409,

        [Description("Source group not found.")]
        SourceGroupNotFound = 40410,

        [Description("Target group not found.")]
        TargetGroupNotFound = 40411,

        [Description("Target app not found.")]
        TargetAppNotFound = 40412,

        [Description("Source tag not found.")]
        SourceTagNotFound = 40413,

        [Description("Target tag not found.")]
        TargetTagNotFound = 40414,

        [Description("No mapping was found.")]
        MappingNotFound = 40415,

        [Description("Configuration not found.")]
        ConfigurationNotFound = 40416,

        [Description("Local setting not found.")]
        LocalSettingNotFound = 40417,

        [Description("Notification not found.")]
        NotificationNotFound = 40418,

        [Description("Generated setting file not found.")]
        GeneratedSettingFileNotFound = 40419,

        [Description("License not found.")]
        LicenseNotFound = 40420,

        [Description("App - Identifier mapping not found.")]
        AppIdentifierMappingNotFound = 40421,

        // NotSupported Errors (40500-40599)

        [Description("Config source not supported.")]
        ConfigSourceNotSupported = 40500,

        [Description("Registration mode singleton not supported.")]
        RegistrationModeSingletonNotSupported = 40501,

        [Description("Registration mode configure not supported.")]
        RegistrationModeConfigureNotSupported = 40502,

        [Description("Ignore on file change not supported due to multiple identical class names.")]
        IgnoreOnFileChangeNotSupported = 40503,

        // Already Exists Errors (40900-40999)

        [Description("Name already exists.")]
        NameAlreadyExists = 40900,

        [Description("Slug already exists.")]
        SlugAlreadyExists = 40901,

        [Description("Group already exists.")]
        GroupAlreadyExists = 40902,

        [Description("Setting identifier already exists.")]
        IdentifierAlreadyExists = 40903,

        [Description("Tag already exists.")]
        TagAlreadyExists = 40904,

        [Description("Mapping already exists.")]
        MappingAlreadyExists = 40905,

        [Description("Sort order with the same value already exists.")]
        DuplicateSortOrder = 40906,

        [Description("Setting already exists in the same identifier.")]
        DuplicateSetting = 40907,

        [Description("Setting with the same computed identifier already exists in the target identifier.")]
        DuplicateTargetSetting = 40908,

        [Description("Computed identifier value must be unique within the same app and setting identifier.")]
        DuplicateComputedIdentifier = 40909,

        [Description("This history has already been restored.")]
        HistoryAlreadyRestored = 40910,

        [Description("Notification already exists.")]
        NotificationAlreadyExists = 40911,

        [Description("License already exists.")]
        LicenseAlreadyExists = 40912,

        [Description("Instance already exists.")]
        InstanceAlreadyExists = 40913,

        // Internal Server Errors (50000-59999)

        [Description("Db update exception occurred.")]
        DbUpdateException = 50000,

        [Description("Failed to fetch content from the source.")]
        ContentFetchFailed = 50001,

        [Description("Data change notification failed.")]
        DataChangeNotificationFailed = 50002
    }
}