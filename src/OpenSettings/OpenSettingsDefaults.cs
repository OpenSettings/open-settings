namespace OpenSettings
{
    /// <summary>
    /// Provides constant values for OpenSettings.
    /// </summary>
    public static class OpenSettingsDefaults
    {
        /// <summary>
        /// Provides constant values for API routes used in OpenSettings.
        /// </summary>
        public static class Routes
        {
            /// <summary>
            /// The V1 API base routes.
            /// </summary>
            public static class V1
            {
                /// <summary>
                /// The AppGroupsController base route.
                /// </summary>
                public const string AppGroups = "v1/app-groups";

                /// <summary>
                /// The AppsController base route.
                /// </summary>
                public const string Apps = "v1/apps";

                /// <summary>
                /// The AuthController base route.
                /// </summary>
                public const string Auth = "v1/auth";

                /// <summary>
                /// The IdentifiersController base route.
                /// </summary>
                public const string Identifiers = "v1/identifiers";

                /// <summary>
                /// The InstancesController base route.
                /// </summary>
                public const string Instances = "v1/instances";

                /// <summary>
                /// The LicensesController base route.
                /// </summary>
                public const string Licenses = "v1/licenses";

                /// <summary>
                /// The LocalSettingsController base route.
                /// </summary>
                public const string LocalSettings = "v1/local-settings";

                /// <summary>
                /// The NotificationsController base route.
                /// </summary>
                public const string Notifications = "v1/notifications";

                /// <summary>
                /// The OpenSettingsController base route.
                /// </summary>
                public const string OpenSettings = "v1/open-settings";

                /// <summary>
                /// The ProviderController base route.
                /// </summary>
                public const string Provider = "v1/provider";

                /// <summary>
                /// The SettingHistoriesController base route.
                /// </summary>
                public const string SettingHistories = "v1/setting-histories";

                /// <summary>
                /// The SettingsController base route.
                /// </summary>
                public const string Settings = "v1/settings";

                /// <summary>
                /// The TagsController base route.
                /// </summary>
                public const string Tags = "v1/tags";

                /// <summary>
                /// The UsersController base route.
                /// </summary>
                public const string Users = "v1/users";
            }
        }

        /// <summary>
        /// Provides constant values for authentication schemes used in OpenSettings.
        /// </summary>
        public static class AuthSchemes
        {
            /// <summary>
            /// The authentication scheme for Basic Authentication in OpenSettings.
            /// </summary>
            public const string Basic = "OpenSettingsBasicAuth";

            /// <summary>
            /// The authentication scheme for Cookie-based Authentication in OpenSettings.
            /// </summary>
            public const string Cookie = "OpenSettingsCookieScheme";

            /// <summary>
            /// The authentication scheme for OAuth2 Authentication in OpenSettings.
            /// </summary>
            public const string OAuth2 = "OpenSettingsOAuth2";

            /// <summary>
            /// The authentication scheme for JWT Bearer Authentication in OpenSettings.
            /// </summary>
            public const string JwtBearer = "OpenSettingsJwtBearer";

            /// <summary>
            /// The authentication scheme for OAuth2 JWT Bearer Authentication in OpenSettings.
            /// </summary>
            public const string OAuth2JwtBearer = "OpenSettingsOAuth2JwtBearer";
        }

        /// <summary>
        /// Provides constant values for claim types used in OpenSettings.
        /// </summary>
        public static class Claims
        {
            public const string DbUserId = "db_user_id";
            public const string DbUserDisplayName = "db_user_displayName";
            public const string DbUserInitials = "db_user_initials";
            public const string DbUserImage = "db_user_image";
        }

        /// <summary>
        /// Provides constant values for header names used in OpenSettings.
        /// </summary>
        public static class HeaderNames
        {
            /// <summary>
            /// The header name used to represent the pack version in OpenSettings.
            /// </summary>
            public const string PackVersion = "x-os-pack-version";

            /// <summary>
            /// The header name used to represent the pack version score in OpenSettings.
            /// </summary>
            public const string PackVersionScore = "x-os-pack-version-score";
        }

        /// <summary>
        /// Provides constant values for task queue names used in OpenSettings.
        /// </summary>
        internal static class TaskQueues
        {
            internal const string Notification = "notification-queue";
            internal const string DataChange = "data-change-queue";
        }
    }
}