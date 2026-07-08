using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSettings.Api.Data.Migrations.OpenSettings.OpenSettingsDb
{
    /// <inheritdoc />
    public partial class InitialOpenSettingsDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptionAlgorithm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationAlgorithm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locks",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locks", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ProviderRegistries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientIdLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InstanceDynamicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scheme = table.Column<int>(type: "int", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastHeartbeatOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderRegistries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    IdentityProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGroups_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppGroups_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppGroups_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTags_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTags_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTags_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GlobalConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SerializerType = table.Column<int>(type: "int", nullable: false),
                    CompressionType = table.Column<int>(type: "int", nullable: false),
                    CompressionLevel = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalConfigurations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlobalConfigurations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlobalConfigurations_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiers_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Identifiers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Identifiers_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceIdLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Holder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolderLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoginEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Issuer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Audience = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    AuthMethod = table.Column<int>(type: "int", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTokenExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Scopes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProviderRegistryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginEntries_ProviderRegistries_ProviderRegistryId",
                        column: x => x.ProviderRegistryId,
                        principalTable: "ProviderRegistries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LoginEntries_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoginEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantUserMappings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUserMappings", x => new { x.TenantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TenantUserMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUserMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNameLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientNameLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientIdLowercase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashedClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_AppGroups_AppGroupId",
                        column: x => x.AppGroupId,
                        principalTable: "AppGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Apps_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GlobalConfigurationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SerializerType = table.Column<int>(type: "int", nullable: false),
                    CompressionType = table.Column<int>(type: "int", nullable: false),
                    CompressionLevel = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestoredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlobalConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RestoredById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigurationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalConfigurationHistories_GlobalConfigurations_GlobalConfigurationId",
                        column: x => x.GlobalConfigurationId,
                        principalTable: "GlobalConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalConfigurationHistories_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlobalConfigurationHistories_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlobalConfigurationHistories_Users_RestoredById",
                        column: x => x.RestoredById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsOpened = table.Column<bool>(type: "bit", nullable: false),
                    OpenedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsViewed = table.Column<bool>(type: "bit", nullable: false),
                    ViewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDismissed = table.Column<bool>(type: "bit", nullable: false),
                    DismissedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationMappings", x => new { x.UserId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaimMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaimMappings", x => new { x.UserId, x.UserClaimId });
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_UserClaims_UserClaimId",
                        column: x => x.UserClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupMappings", x => new { x.UserId, x.UserGroupId });
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupNotificationMappings",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupNotificationMappings", x => new { x.UserGroupId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroupUserClaimMappings",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupUserClaimMappings", x => new { x.UserGroupId, x.UserClaimId });
                    table.ForeignKey(
                        name: "FK_UserGroupUserClaimMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupUserClaimMappings_UserClaims_UserClaimId",
                        column: x => x.UserClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupUserClaimMappings_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupUserClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMappings", x => new { x.UserId, x.UserRoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleUserClaimMappings",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleUserClaimMappings", x => new { x.UserRoleId, x.UserClaimId });
                    table.ForeignKey(
                        name: "FK_UserRoleUserClaimMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleUserClaimMappings_UserClaims_UserClaimId",
                        column: x => x.UserClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUserClaimMappings_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUserClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoleUserGroupMappings",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleUserGroupMappings", x => new { x.UserRoleId, x.UserGroupId });
                    table.ForeignKey(
                        name: "FK_UserRoleUserGroupMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleUserGroupMappings_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUserGroupMappings_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUserGroupMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreInSeparateFile = table.Column<bool>(type: "bit", nullable: false),
                    IgnoreIndividualStoreInSeparateFile = table.Column<bool>(type: "bit", nullable: false),
                    IgnoreOnFileChange = table.Column<bool>(type: "bit", nullable: false),
                    IgnoreIndividualIgnoreOnFileChange = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationMode = table.Column<int>(type: "int", nullable: false),
                    IgnoreIndividualRegistrationMode = table.Column<bool>(type: "bit", nullable: false),
                    Consumer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppConfigurations_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppConfigurations_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppConfigurations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppConfigurations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppConfigurations_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppIdentifierMappings",
                columns: table => new
                {
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIdentifierMappings", x => new { x.AppId, x.IdentifierId });
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLowercase = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DynamicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReloadStrategies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    DataAccessType = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInstances_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInstances_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInstances_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ComputedIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerializerType = table.Column<int>(type: "int", nullable: false),
                    CompressionType = table.Column<int>(type: "int", nullable: false),
                    CompressionLevel = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRestored = table.Column<bool>(type: "bit", nullable: false),
                    DataValidationDisabled = table.Column<bool>(type: "bit", nullable: false),
                    StoreInSeparateFile = table.Column<bool>(type: "bit", nullable: false),
                    IgnoreOnFileChange = table.Column<bool>(type: "bit", nullable: true),
                    RegistrationMode = table.Column<int>(type: "int", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    IsCopied = table.Column<bool>(type: "bit", nullable: false),
                    CopiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopiedFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSettings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSettings_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettings_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppTagMappings",
                columns: table => new
                {
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTagMappings", x => new { x.AppId, x.AppTagId });
                    table.ForeignKey(
                        name: "FK_AppTagMappings_AppTags_AppTagId",
                        column: x => x.AppTagId,
                        principalTable: "AppTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppSettingClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettingClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSettingClasses_AppSettings_AppSettingId",
                        column: x => x.AppSettingId,
                        principalTable: "AppSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSettingClasses_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettingClasses_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettingClasses_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppSettingHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SerializerType = table.Column<int>(type: "int", nullable: false),
                    CompressionType = table.Column<int>(type: "int", nullable: false),
                    CompressionLevel = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestoredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RestoredById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSettingHistories_AppSettings_AppSettingId",
                        column: x => x.AppSettingId,
                        principalTable: "AppSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSettingHistories_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettingHistories_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSettingHistories_Users_RestoredById",
                        column: x => x.RestoredById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_AppId_IdentifierId",
                table: "AppConfigurations",
                columns: new[] { "AppId", "IdentifierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_CreatedById",
                table: "AppConfigurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_IdentifierId",
                table: "AppConfigurations",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_TenantId",
                table: "AppConfigurations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_UpdatedById",
                table: "AppConfigurations",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_CreatedById",
                table: "AppGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_SortOrder",
                table: "AppGroups",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_TenantId_Slug",
                table: "AppGroups",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_UpdatedById",
                table: "AppGroups",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_CreatedById",
                table: "AppIdentifierMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_IdentifierId",
                table: "AppIdentifierMappings",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_SortOrder",
                table: "AppIdentifierMappings",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_TenantId",
                table: "AppIdentifierMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_UpdatedById",
                table: "AppIdentifierMappings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppInstances_AppId_IdentifierId_Slug",
                table: "AppInstances",
                columns: new[] { "AppId", "IdentifierId", "Slug" },
                unique: true,
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppInstances_IdentifierId",
                table: "AppInstances",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInstances_NameLowercase",
                table: "AppInstances",
                column: "NameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_AppInstances_TenantId",
                table: "AppInstances",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AppGroupId",
                table: "Apps",
                column: "AppGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ClientNameLowercase",
                table: "Apps",
                column: "ClientNameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_CreatedById",
                table: "Apps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_TenantId_ClientId",
                table: "Apps",
                columns: new[] { "TenantId", "ClientId" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_TenantId_Slug",
                table: "Apps",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_UpdatedById",
                table: "Apps",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingClasses_AppSettingId",
                table: "AppSettingClasses",
                column: "AppSettingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingClasses_CreatedById",
                table: "AppSettingClasses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingClasses_TenantId",
                table: "AppSettingClasses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingClasses_UpdatedById",
                table: "AppSettingClasses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_AppSettingId",
                table: "AppSettingHistories",
                column: "AppSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_CreatedById",
                table: "AppSettingHistories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_RestoredById",
                table: "AppSettingHistories",
                column: "RestoredById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_Slug_AppSettingId",
                table: "AppSettingHistories",
                columns: new[] { "Slug", "AppSettingId" },
                unique: true,
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_TenantId",
                table: "AppSettingHistories",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettingHistories_Version",
                table: "AppSettingHistories",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_AppId_IdentifierId_ComputedIdentifier",
                table: "AppSettings",
                columns: new[] { "AppId", "IdentifierId", "ComputedIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_CreatedById",
                table: "AppSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_IdentifierId",
                table: "AppSettings",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_TenantId",
                table: "AppSettings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_UpdatedById",
                table: "AppSettings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppTagMappings_AppTagId",
                table: "AppTagMappings",
                column: "AppTagId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTagMappings_CreatedById",
                table: "AppTagMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppTagMappings_TenantId",
                table: "AppTagMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTags_CreatedById",
                table: "AppTags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppTags_SortOrder",
                table: "AppTags",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AppTags_TenantId_NameLowercase",
                table: "AppTags",
                columns: new[] { "TenantId", "NameLowercase" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [NameLowercase] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppTags_TenantId_Slug",
                table: "AppTags",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppTags_UpdatedById",
                table: "AppTags",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_CreatedById",
                table: "GlobalConfigurationHistories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_GlobalConfigurationId",
                table: "GlobalConfigurationHistories",
                column: "GlobalConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_Key_ClientId_IdentifierId",
                table: "GlobalConfigurationHistories",
                columns: new[] { "Key", "ClientId", "IdentifierId" },
                unique: true,
                filter: "[Key] IS NOT NULL AND [ClientId] IS NOT NULL AND [IdentifierId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_RestoredById",
                table: "GlobalConfigurationHistories",
                column: "RestoredById");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_TenantId",
                table: "GlobalConfigurationHistories",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurationHistories_Version",
                table: "GlobalConfigurationHistories",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurations_CreatedById",
                table: "GlobalConfigurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurations_Key_ClientId_IdentifierId",
                table: "GlobalConfigurations",
                columns: new[] { "Key", "ClientId", "IdentifierId" },
                unique: true,
                filter: "[Key] IS NOT NULL AND [ClientId] IS NOT NULL AND [IdentifierId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurations_TenantId",
                table: "GlobalConfigurations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalConfigurations_UpdatedById",
                table: "GlobalConfigurations",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_CreatedById",
                table: "Identifiers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_NameLowercase",
                table: "Identifiers",
                column: "NameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_SortOrder",
                table: "Identifiers",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_TenantId_Slug",
                table: "Identifiers",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UpdatedById",
                table: "Identifiers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_Edition",
                table: "Licenses",
                column: "Edition");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_HolderLowercase",
                table: "Licenses",
                column: "HolderLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_IsExpired",
                table: "Licenses",
                column: "IsExpired");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ReferenceIdLowercase",
                table: "Licenses",
                column: "ReferenceIdLowercase",
                unique: true,
                filter: "[ReferenceIdLowercase] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_TenantId",
                table: "Licenses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_CreatedOn",
                table: "LoginEntries",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_ProviderRegistryId",
                table: "LoginEntries",
                column: "ProviderRegistryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_StateId",
                table: "LoginEntries",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_StateId_AuthMethod_CreatedOn_IsSuccessful",
                table: "LoginEntries",
                columns: new[] { "StateId", "AuthMethod", "CreatedOn", "IsSuccessful" });

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_TenantId",
                table: "LoginEntries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginEntries_UserId",
                table: "LoginEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedById",
                table: "Notifications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TenantId",
                table: "Notifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UpdatedById",
                table: "Notifications",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRegistries_ClientIdLowercase",
                table: "ProviderRegistries",
                column: "ClientIdLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRegistries_LastHeartbeatOn",
                table: "ProviderRegistries",
                column: "LastHeartbeatOn");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRegistries_Type",
                table: "ProviderRegistries",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CreatedById",
                table: "Tenants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Slug",
                table: "Tenants",
                column: "Slug",
                unique: true,
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_UpdatedById",
                table: "Tenants",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUserMappings_UserId",
                table: "TenantUserMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimMappings_CreatedById",
                table: "UserClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimMappings_TenantId",
                table: "UserClaimMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimMappings_UserClaimId",
                table: "UserClaimMappings",
                column: "UserClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_TenantId_Slug",
                table: "UserClaims",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_CreatedById",
                table: "UserGroupMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_TenantId",
                table: "UserGroupMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_UserGroupId",
                table: "UserGroupMappings",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupNotificationMappings_CreatedById",
                table: "UserGroupNotificationMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupNotificationMappings_NotificationId",
                table: "UserGroupNotificationMappings",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupNotificationMappings_TenantId",
                table: "UserGroupNotificationMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_TenantId_Slug",
                table: "UserGroups",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupUserClaimMappings_CreatedById",
                table: "UserGroupUserClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupUserClaimMappings_TenantId",
                table: "UserGroupUserClaimMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupUserClaimMappings_UserClaimId",
                table: "UserGroupUserClaimMappings",
                column: "UserClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationMappings_CreatedById",
                table: "UserNotificationMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationMappings_NotificationId",
                table: "UserNotificationMappings",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationMappings_TenantId",
                table: "UserNotificationMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_CreatedById",
                table: "UserRoleMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_TenantId",
                table: "UserRoleMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_UserRoleId",
                table: "UserRoleMappings",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_TenantId_Slug",
                table: "UserRoles",
                columns: new[] { "TenantId", "Slug" },
                unique: true,
                filter: "[TenantId] IS NOT NULL AND [Slug] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserClaimMappings_CreatedById",
                table: "UserRoleUserClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserClaimMappings_TenantId",
                table: "UserRoleUserClaimMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserClaimMappings_UserClaimId",
                table: "UserRoleUserClaimMappings",
                column: "UserClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserGroupMappings_CreatedById",
                table: "UserRoleUserGroupMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserGroupMappings_TenantId",
                table: "UserRoleUserGroupMappings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserGroupMappings_UserGroupId",
                table: "UserRoleUserGroupMappings",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Slug",
                table: "Users",
                column: "Slug",
                unique: true,
                filter: "[Slug] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigurations");

            migrationBuilder.DropTable(
                name: "AppIdentifierMappings");

            migrationBuilder.DropTable(
                name: "AppInstances");

            migrationBuilder.DropTable(
                name: "AppSettingClasses");

            migrationBuilder.DropTable(
                name: "AppSettingHistories");

            migrationBuilder.DropTable(
                name: "AppTagMappings");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "GlobalConfigurationHistories");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Locks");

            migrationBuilder.DropTable(
                name: "LoginEntries");

            migrationBuilder.DropTable(
                name: "TenantUserMappings");

            migrationBuilder.DropTable(
                name: "UserClaimMappings");

            migrationBuilder.DropTable(
                name: "UserGroupMappings");

            migrationBuilder.DropTable(
                name: "UserGroupNotificationMappings");

            migrationBuilder.DropTable(
                name: "UserGroupUserClaimMappings");

            migrationBuilder.DropTable(
                name: "UserNotificationMappings");

            migrationBuilder.DropTable(
                name: "UserRoleMappings");

            migrationBuilder.DropTable(
                name: "UserRoleUserClaimMappings");

            migrationBuilder.DropTable(
                name: "UserRoleUserGroupMappings");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "AppTags");

            migrationBuilder.DropTable(
                name: "GlobalConfigurations");

            migrationBuilder.DropTable(
                name: "ProviderRegistries");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "AppGroups");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
