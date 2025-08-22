﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventModular.Server.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "jobs");

            migrationBuilder.CreateSequence<int>(
                name: "ProductShortId",
                schema: "dbo",
                startValue: 10051L);

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.Id, x.Kind });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireCounter",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireCounter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireHash",
                schema: "jobs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Field = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireHash", x => new { x.Key, x.Field });
                });

            migrationBuilder.CreateTable(
                name: "HangfireList",
                schema: "jobs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireList", x => new { x.Key, x.Position });
                });

            migrationBuilder.CreateTable(
                name: "HangfireLock",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireLock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireServer",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heartbeat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkerCount = table.Column<int>(type: "int", nullable: false),
                    Queues = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireSet",
                schema: "jobs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireSet", x => new { x.Key, x.Value });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemPrompts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    PromptKind = table.Column<int>(type: "int", nullable: false),
                    Markdown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemPrompts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EmailTokenRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PhoneNumberTokenRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ResetPasswordTokenRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TwoFactorTokenRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OtpRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ElevatedAccessTokenRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    HasProfilePicture = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    ShortId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [dbo].[ProductShortId]"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescriptionHTML = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    HasPrimaryImage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privileged = table.Column<bool>(type: "bit", nullable: false),
                    StartedOn = table.Column<long>(type: "bigint", nullable: false),
                    RenewedOn = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignalRConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationStatus = table.Column<int>(type: "int", nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformType = table.Column<int>(type: "int", nullable: true),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewSequentialID()"),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebAuthnCredential",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(900)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SignCount = table.Column<long>(type: "bigint", nullable: false),
                    Transports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBackupEligible = table.Column<bool>(type: "bit", nullable: false),
                    IsBackedUp = table.Column<bool>(type: "bit", nullable: false),
                    AttestationObject = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AttestationClientDataJson = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserHandle = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AttestationFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AaGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebAuthnCredential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebAuthnCredential_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PushNotificationSubscriptions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P256dh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationTime = table.Column<long>(type: "bigint", nullable: false),
                    RenewedOn = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotificationSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PushNotificationSubscriptions_UserSessions_UserSessionId",
                        column: x => x.UserSessionId,
                        principalSchema: "dbo",
                        principalTable: "UserSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HangfireJob",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvocationData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireJobParameter",
                schema: "jobs",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireJobParameter", x => new { x.JobId, x.Name });
                    table.ForeignKey(
                        name: "FK_HangfireJobParameter_HangfireJob_JobId",
                        column: x => x.JobId,
                        principalSchema: "jobs",
                        principalTable: "HangfireJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HangfireQueuedJob",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Queue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FetchedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireQueuedJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangfireQueuedJob_HangfireJob_JobId",
                        column: x => x.JobId,
                        principalSchema: "jobs",
                        principalTable: "HangfireJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HangfireState",
                schema: "jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangfireState_HangfireJob_JobId",
                        column: x => x.JobId,
                        principalSchema: "jobs",
                        principalTable: "HangfireJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categories",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), "#FFCD56", "Ford" },
                    { new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), "#FF6384", "Nissan" },
                    { new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), "#4BC0C0", "Benz" },
                    { new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), "#2B88D8", "Tesla" },
                    { new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), "#FF9124", "BMW" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8ff71671-a1d6-5f97-abb9-d87d7b47d6e7"), "8ff71671-a1d6-5f97-abb9-d87d7b47d6e7", "s-admin", "S-ADMIN" },
                    { new Guid("9ff71672-a1d5-4f97-abb7-d87d6b47d5e8"), "9ff71672-a1d5-4f97-abb7-d87d6b47d5e8", "demo", "DEMO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemPrompts",
                columns: new[] { "Id", "Markdown", "PromptKind" },
                values: new object[] { new Guid("a8c94d94-0004-4dd0-921c-255e0a581424"), "You are a assistant for the EventModular app. Below, you will find a markdown document containing information about the app, followed by the user's query.\r\n\r\n# EventModular app - Features and usage guide\r\n\r\n**[[[GENERAL_INFORMATION_BEGIN]]]**\r\n\r\n*   **Platforms:** The application is available on Android, iOS, Windows, macOS, and as a Web (PWA) application.\r\n\r\n* Website address: [Website address](https://sales.bitplatform.dev/)\r\n* Google Play: [Google Play Link](https://play.google.com/store/apps/details?id=com.bitplatform.AdminPanel.Template)\r\n* Apple Store: [Apple Store Link](https://apps.apple.com/us/app/bit-adminpanel/id6450611349)\r\n* Windows EXE installer: [Windows app link](https://windows-admin.bitplatform.dev/AdminPanel.Client.Windows-win-Setup.exe)\r\n\r\n## 1. Account Management & Authentication\r\n\r\nThese features cover user sign-up, sign-in, account recovery, and security settings.\r\n\r\n### 1.1. Sign Up\r\n*   **Description:** Allows new users to create an account. Users can sign up using their email address, phone number, or via social providers.\r\n*   **How to Use:**\r\n    - Navigate to the [Sign Up page](/sign-up).\r\n\r\n### 1.2. Sign In\r\n*   **Description:** Allows existing users to sign into their accounts using various methods.\r\n*   **How to Use:**\r\n    - Navigate to the [Sign In page](/sign-in).\r\n\r\n### 1.3. Confirm Account\r\n*   **Description:** Verifies a user's email address or phone number after sign-up, typically by entering a code sent to them.\r\n*   **How to Use:**\r\n    - Navigate to the [Confirmation page](/confirm) (often automatic redirection after sign-up).\r\n\r\n### 1.4. Forgot Password\r\n*   **Description:** Initiates the password reset process by sending a reset token (code) to the user's registered email or phone number.\r\n*   **How to Use:**\r\n    - Navigate to the [Forgot Password page](/forgot-password), often linked from the Sign In page.\r\n\r\n### 1.5. Reset Password\r\n*   **Description:** Allows users to set a new password after requesting a reset token via the Forgot Password flow.\r\n*   **How to Use:**\r\n    - Navigate to the [Reset Password page](/reset-password).\r\n\r\n## 2. User Settings\r\n\r\nAccessible after signing in, these pages allow users to manage their profile, account details, security settings, and active sessions.\r\n\r\n### 2.1. Profile Settings\r\n*   **Description:** Manage personal user information like name, profile picture, birthdate, and gender.\r\n*   **How to Use:**\r\n    - Navigate to the [Profile page](/settings/profile).\r\n\r\n### 2.2. Account Settings\r\n*   **Description:** Manage account-specific details like email, phone number, enable passwordless sign-in, and account deletion.\r\n*   **How to Use:**\r\n    - Navigate to the [Account page](/settings/account).\r\n\r\n### 2.3. Two-Factor Authentication (2FA)\r\n*   **Description:** Enhance account security by requiring a second form of verification (typically a code from an authenticator app) during sign-in.\r\n*   **How to Use:**\r\n    - Navigate to the [Two Factor Authentication page](/settings/tfa).\r\n\r\n### 2.4. Session Management\r\n*   **Description:** View all devices and browsers where the user is currently signed in and provides the ability to sign out (revoke) specific sessions remotely.\r\n*   **How to Use:**\r\n    - Navigate to the [Sessions page](/settings/sessions).\r\n\r\n## 3. Core Application Features\r\n\r\nThese are the primary functional areas of the application beyond account management.\r\n### 3.1. Dashboard\r\n*   **Description:** Provides a high-level overview and analytics of key application data, such as categories and products.\r\n*   **How to Use:**\r\n    - Navigate to the [Dashboard page](/dashboard).\r\n\r\n### 3.2. Categories Management\r\n*   **Description:** Allows users to view, create, edit, and delete categories, often used to organize products.\r\n*   **How to Use:**\r\n    - Navigate to the [Categories page](/categories).\r\n\r\n### 3.3. Products Management\r\n*   **Description:** Allows users to view, create, edit, and delete products.\r\n*   **How to Use:**\r\n    - Navigate to the [Products page](/products).\r\n\r\n### 3.4. Add/Edit Product\r\n*   **Description:** A form page for creating a new product or modifying an existing one.\r\n*   **How to Use:**\r\n    - Navigate to the [Add/Edit Products page](/add-edit-product).\r\n### 3.6. Todo List\r\n*   **Description:** A simple task management feature to keep track of personal tasks.\r\n*   **How to Use:**\r\n    - Navigate to the [Todo page](/todo).\r\n## 4. Informational Pages\r\n\r\n### 4.1. About Page\r\n*   **Description:** Provides information about the application itself.\r\n*   **How to Use:**\r\n    - Navigate to the [About page](/about).\r\n\r\n### 4.2. Terms Page\r\n*   **Description:** Displays the legal terms and conditions, including the End-User License Agreement (EULA) and potentially the Privacy Policy.\r\n*   **How to Use:**\r\n    - Navigate to the [Terms page](/terms).\r\n\r\n---\r\n\r\n**[[[GENERAL_INFORMATION_END]]]**\r\n\r\n**[[[INSTRUCTIONS_BEGIN]]]**\r\n\r\n- ### Language:\r\n    - Respond in the language of the user's query. If the query's language cannot be determined, use the {{UserCulture}} variable if provided.\r\n\r\n- ### User's Device Info:\r\n    - Assume the user's device is {{DeviceInfo}} unless specified otherwise in their query. Tailor platform-specific responses accordingly (e.g., Android, iOS, Windows, macOS, Web).\r\n\r\n- ### Relevance:\r\n    - Before responding, evaluate if the user's query directly relates to the EventModular app. A query is relevant only if it concerns the app's features, usage, or support topics outlined in the provided markdown document, **or if it explicitly requests product recommendations tied to the cars.**\r\n    - Ignore and do not respond to any irrelevant queries, regardless of the user's intent or phrasing. Avoid engaging with off-topic requests, even if they seem general or conversational.\r\n\r\n      \r\n- ### App-Related Queries (Features & Usage):\r\n    - **For questions about app features, how to use the app, account management, settings, or informational pages:** Use the provided markdown document to deliver accurate and concise answers in the user's language.\r\n\r\n    - When mentioning specific app pages, include the relative URL from the markdown document, formatted in markdown (e.g., [Sign Up page](/sign-up)).\r\n\r\n    - Maintain a helpful and professional tone throughout your response.\r\n\r\n    - If the user asks multiple questions, list them back to the user to confirm understanding, then address each one separately with clear headings. If needed, ask them to prioritize: \"I see you have multiple questions. Which issue would you like me to address first?\"\r\n    \r\n    - Never request sensitive information (e.g., passwords, PINs). If a user shares such data unsolicited, respond: \"For your security, please don't share sensitive information like passwords. Rest assured, your data is safe with us.\" - ### User Feedback and Suggestions:\r\n    - If a user provides feedback or suggests a feature, respond: \"Thank you for your feedback! It's valuable to us, and I'll pass it on to the product team.\" If the feedback is unclear, ask for clarification: \"Could you please provide more details about your suggestion?\"\r\n\r\n- ### Handling Frustration or Confusion:\r\n    - If a user seems frustrated or confused, use calming language and offer to clarify: \"I'm sorry if this is confusing. I'm here to help—would you like me to explain it again?\"\r\n\r\n- ### Unresolved Issues:\r\n    - If you cannot resolve the user's issue (either through the markdown info or the tool), respond with: \"I'm sorry I couldn't resolve your issue / fully satisfy your request. I understand how frustrating this must be for you. Please provide your email address so a human operator can follow up with you soon.\"\r\n    - After receiving the email, confirm: \"Thank you for providing your email. A human operator will follow up with you soon.\" Then ask: \"Do you have any other issues you'd like me to assist with?\"\r\n\r\n**[[[INSTRUCTIONS_END]]]**", 0 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "ElevatedAccessTokenRequestedOn", "Email", "EmailConfirmed", "EmailTokenRequestedOn", "FullName", "Gender", "HasProfilePicture", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OtpRequestedOn", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhoneNumberTokenRequestedOn", "ResetPasswordTokenRequestedOn", "SecurityStamp", "TwoFactorEnabled", "TwoFactorTokenRequestedOn", "UserName" },
                values: new object[] { new Guid("8ff71671-a1d6-4f97-abb9-d87d7b47d6e7"), 0, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "315e1a26-5b3a-4544-8e91-2760cd28e231", null, "test@bitplatform.dev", true, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "EventModular test account", 0, false, true, null, "TEST@BITPLATFORM.DEV", "TEST", null, "AQAAAAIAAYagAAAAEP0v3wxkdWtMkHA3Pp5/JfS+42/Qto9G05p2mta6dncSK37hPxEHa3PGE4aqN30Aag==", "+31684207362", true, null, null, "959ff4a9-4b07-4cc1-8141-c5fc033daf83", false, null, "test" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DescriptionHTML", "DescriptionText", "HasPrimaryImage", "Name", "Price", "ShortId" },
                values: new object[,]
                {
                    { new Guid("10e9f8e7-b6a5-d4c3-b2a1-d0e9f8e7b6a5"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Driving performance, elevated.</h3><p>Born on the racetrack, the AMG GT Coupe embodies the essence of a pure sports car with breathtaking power and precision handling.</p>", "Driving performance, elevated.\nBorn on the racetrack, the AMG GT Coupe embodies the essence of a pure sports car with breathtaking power and precision handling.\n", false, "Mercedes-AMG GT Coupe", 150000m, 10018 },
                    { new Guid("21d0e9f8-e7b6-a5d4-c3b2-a1d0e9f8e7b6"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Sporty elegance, redefined.</h3><p>The all-new CLE Coupe merges expressive design with dynamic handling and advanced technology, creating a modern icon of desire.</p>", "Sporty elegance, redefined.\nThe all-new CLE Coupe merges expressive design with dynamic handling and advanced technology, creating a modern icon of desire.\n", false, "CLE Coupe", 65000m, 10017 },
                    { new Guid("32a1d0e9-f8e7-b6a5-d4c3-b2a1d0e9f8e7"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Irresistible from every angle.</h3><p>With its iconic sloping roofline and sporty stance, the CLA Coupe captivates with expressive design and agile performance.</p>", "Irresistible from every angle.\nWith its iconic sloping roofline and sporty stance, the CLA Coupe captivates with expressive design and agile performance.\n", false, "CLA COUPE", 50500m, 10016 },
                    { new Guid("43b2a1d0-e9f8-e7b6-a5d4-c3b2a1d0e9f8"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The pinnacle of automotive desire.</h3><p>Engineered without compromise, the S-Class Sedan pioneers innovations in safety, comfort, and driving experience, defining luxury travel.</p>", "The pinnacle of automotive desire.\nEngineered without compromise, the S-Class Sedan pioneers innovations in safety, comfort, and driving experience, defining luxury travel.\n", false, "S-Class Sedan", 140000m, 10015 },
                    { new Guid("512eb70b-1d39-4845-88c0-fe19cd2d1979"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Advanced, adaptive, adventurous.</h3><p>More than new, it can update its advancements down the road. More than thoughtful, it can anticipate needs and desires. Beyond futuristic, it can make better use of your time, and make your time using it better.</p>", "Advanced, adaptive, adventurous.\nMore than new, it can update its advancements down the road. More than thoughtful, it can anticipate needs and desires. Beyond futuristic, it can make better use of your time, and make your time using it better.\n", false, "EQE SUV", 79050m, 10003 },
                    { new Guid("54c3b2a1-d0e9-f8e7-b6a5-d4c3b2a1d0e9"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The heart of the brand, intelligently refined.</h3><p>A masterpiece of intelligence, the E-Class Sedan seamlessly blends dynamic design, luxurious comfort, and groundbreaking driver assistance systems.</p>", "The heart of the brand, intelligently refined.\nA masterpiece of intelligence, the E-Class Sedan seamlessly blends dynamic design, luxurious comfort, and groundbreaking driver assistance systems.\n", false, "E-Class Sedan", 73900m, 10014 },
                    { new Guid("5746ae3d-5116-4774-9d55-0ff496e5186f"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Electric, essential, quintessential</h3><p>It's futuristic, forward and fresh, but you know its core values. Ever-refined luxury. Ever-advancing innovation. And a never-ending devotion to your well-being. Perhaps no electric sedan feels so new, yet so natural.</p>", "Electric, essential, quintessential\nIt's futuristic, forward and fresh, but you know its core values. Ever-refined luxury. Ever-advancing innovation. And a never-ending devotion to your well-being. Perhaps no electric sedan feels so new, yet so natural.\n", false, "EQE Sedan", 76050m, 10001 },
                    { new Guid("65d4c3b2-a1d0-e9f8-e7b6-a5d4c3b2a1d0"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>An icon reengineered.</h3><p>Instantly recognizable, eternally capable. The G-Class remains the definitive luxury off-roader, blending timeless design with modern technology and rugged performance.</p>", "An icon reengineered.\nInstantly recognizable, eternally capable. The G-Class remains the definitive luxury off-roader, blending timeless design with modern technology and rugged performance.\n", false, "G-CLASS SUV", 180000m, 10013 },
                    { new Guid("76a5d4c3-b2a1-d0e9-f8e7-b6a5d4c3b2a1"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The S-Class of SUVs.</h3><p>Offering first-class travel for up to seven passengers, the GLS combines commanding presence with unparalleled luxury, space, and technology.</p>", "The S-Class of SUVs.\nOffering first-class travel for up to seven passengers, the GLS combines commanding presence with unparalleled luxury, space, and technology.\n", false, "GLS SUV", 115100m, 10012 },
                    { new Guid("87b6a5d4-c3b2-a1d0-e9f8-e7b6a5d4c3b2"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Athletic presence, commanding performance.</h3><p>The GLE Coupe blends the muscular stance of an SUV with the elegant lines of a coupe, delivering exhilarating performance and undeniable style.</p>", "Athletic presence, commanding performance.\nThe GLE Coupe blends the muscular stance of an SUV with the elegant lines of a coupe, delivering exhilarating performance and undeniable style.\n", false, "GLE Coupe", 94900m, 10011 },
                    { new Guid("98e7b6a5-d4c3-b2a1-d0e9-f8e7b6a5d4c3"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Master of every ground.</h3><p>Intelligent, spacious, and capable, the GLE SUV offers cutting-edge technology and luxurious comfort for families and adventurers alike.</p>", "Master of every ground.\nIntelligent, spacious, and capable, the GLE SUV offers cutting-edge technology and luxurious comfort for families and adventurers alike.\n", false, "GLE SUV", 82800m, 10010 },
                    { new Guid("9a59dda2-7b12-4cc1-9658-d2586eef91d7"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Range to roam. Room for up to 7.</h3><p>It's a versatile SUV with room for up to seven. And an advanced EV you can enjoy every day. Intelligent technology and thoughtful luxury are delivered with swift response and silenced refinement.</p>", "Range to roam. Room for up to 7.\nIt's a versatile SUV with room for up to seven. And an advanced EV you can enjoy every day. Intelligent technology and thoughtful luxury are delivered with swift response and silenced refinement.\n", false, "EQB SUV", 54200m, 10000 },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Built Ford Tough.</h3><p>America's best-selling truck, known for its capability, innovation, and toughness for work or play.</p>", "Built Ford Tough.\nAmerica's best-selling truck, known for its capability, innovation, and toughness for work or play.\n", false, "Ford F-150", 45000m, 10020 },
                    { new Guid("a1b2c3d4-e5f6-a7b8-9012-3456c7d8e9f0"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Radical Electric Pickup.</h3><p>A futuristic pickup truck with an exoskeleton design, offering utility, performance, and durability.</p>", "Radical Electric Pickup.\nA futuristic pickup truck with an exoskeleton design, offering utility, performance, and durability.\n", false, "Tesla Cybertruck", 70000m, 10050 },
                    { new Guid("a3b4c5d6-e7f8-a9b0-1234-5678c9d0e1f2"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Right-Sized Pickup.</h3><p>A capable and durable mid-size truck designed for both work duties and weekend adventures.</p>", "Right-Sized Pickup.\nA capable and durable mid-size truck designed for both work duties and weekend adventures.\n", false, "Nissan Frontier", 35000m, 10032 },
                    { new Guid("a5b6c7d8-e9f0-a1b2-3456-7890c1d2e3f4"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Mass-Market Electric Sedan.</h3><p>Tesla's most affordable car, offering impressive range, performance, and minimalist design.</p>", "Mass-Market Electric Sedan.\nTesla's most affordable car, offering impressive range, performance, and minimalist design.\n", false, "Tesla Model 3", 45000m, 10044 },
                    { new Guid("a7b8c9d0-e1f2-a3b4-5678-9012c3d4e5f6"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Compact Truck, Big Ideas.</h3><p>An affordable and versatile compact pickup, available with a standard hybrid powertrain.</p>", "Compact Truck, Big Ideas.\nAn affordable and versatile compact pickup, available with a standard hybrid powertrain.\n", false, "Ford Maverick", 28000m, 10026 },
                    { new Guid("a9b0c1d2-e3f4-a5b6-7890-1234c5d6e7f8"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The Boss.</h3><p>The original Sports Activity Vehicle, setting benchmarks for luxury, performance, and capability in its class.</p>", "The Boss.\nThe original Sports Activity Vehicle, setting benchmarks for luxury, performance, and capability in its class.\n", false, "BMW X5 SAV", 70000m, 10038 },
                    { new Guid("a9f8e7b6-a5d4-c3b2-a1d0-e9f8e7b6a5d4"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Sporty style, SUV substance.</h3><p>Combining the dynamic presence of a coupe with the versatility of an SUV, the GLC Coupe makes a powerful statement on any road.</p>", "Sporty style, SUV substance.\nCombining the dynamic presence of a coupe with the versatility of an SUV, the GLC Coupe makes a powerful statement on any road.\n", false, "GLC Coupe", 63500m, 10009 },
                    { new Guid("b0a9f8e7-b6a5-d4c3-b2a1-d0e9f8e7b6a5"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Intelligent drive, impressive design.</h3><p>The GLC SUV sets benchmarks for comfort, technology, and performance in the mid-size luxury segment, adapting effortlessly to your driving needs.</p>", "Intelligent drive, impressive design.\nThe GLC SUV sets benchmarks for comfort, technology, and performance in the mid-size luxury segment, adapting effortlessly to your driving needs.\n", false, "GLC SUV", 58900m, 10008 },
                    { new Guid("b0c1d2e3-f4a5-b6c7-8901-2345d6e7f8a9"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Executive Athleticism.</h3><p>A sophisticated blend of dynamic performance, cutting-edge technology, and luxurious comfort for the executive class.</p>", "Executive Athleticism.\nA sophisticated blend of dynamic performance, cutting-edge technology, and luxurious comfort for the executive class.\n", false, "BMW 5 Series Sedan", 65000m, 10039 },
                    { new Guid("b2c3d4e5-f6a7-89b0-12c3-45d678e9f0a1"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Iconic American Muscle.</h3><p>Thrilling performance and unmistakable style define the legendary Ford Mustang coupe.</p>", "Iconic American Muscle.\nThrilling performance and unmistakable style define the legendary Ford Mustang coupe.\n", false, "Ford Mustang", 40000m, 10021 },
                    { new Guid("b4c5d6e7-f8a9-b0c1-2345-6789d0e1f2a3"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Expressive Subcompact Crossover.</h3><p>Stand out with customizable style and enjoy city-friendly agility and smart technology.</p>", "Expressive Subcompact Crossover.\nStand out with customizable style and enjoy city-friendly agility and smart technology.\n", false, "Nissan Kicks", 24000m, 10033 },
                    { new Guid("b6c7d8e9-f0a1-b2c3-4567-8901d2e3f4a5"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Compact Electric SUV.</h3><p>A versatile electric SUV offering ample space, performance, and access to Tesla's Supercharger network.</p>", "Compact Electric SUV.\nA versatile electric SUV offering ample space, performance, and access to Tesla's Supercharger network.\n", false, "Tesla Model Y", 55000m, 10045 },
                    { new Guid("b8c9d0e1-f2a3-b4c5-6789-0123d4e5f6a7"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Stylish Mid-Size Crossover.</h3><p>Combines sophisticated design with smart technology and engaging performance in a two-row crossover.</p>", "Stylish Mid-Size Crossover.\nCombines sophisticated design with smart technology and engaging performance in a two-row crossover.\n", false, "Ford Edge", 40000m, 10027 },
                    { new Guid("c1b0a9f8-e7b6-a5d4-c3b2-a1d0e9f8e7b6"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Versatility meets space.</h3><p>Surprisingly spacious for its size, the GLB offers an optional third row, making it the flexible and family-friendly compact SUV for all your adventures.</p>", "Versatility meets space.\nSurprisingly spacious for its size, the GLB offers an optional third row, making it the flexible and family-friendly compact SUV for all your adventures.\n", false, "GLB SUV", 52500m, 10007 },
                    { new Guid("c1d2e3f4-a5b6-c7d8-9012-3456e7f8a9b0"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Electric Performance Coupe.</h3><p>BMW's first all-electric Gran Coupe, delivering impressive range and signature BMW driving dynamics.</p>", "Electric Performance Coupe.\nBMW's first all-electric Gran Coupe, delivering impressive range and signature BMW driving dynamics.\n", false, "BMW i4 Gran Coupe", 60000m, 10040 },
                    { new Guid("c3d4e5f6-a7b8-9c01-23d4-56e789f0a1b2"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Adventure Ready SUV.</h3><p>A spacious and capable SUV designed for family adventures, offering three rows of seating and modern tech.</p>", "Adventure Ready SUV.\nA spacious and capable SUV designed for family adventures, offering three rows of seating and modern tech.\n", false, "Ford Explorer", 48000m, 10022 },
                    { new Guid("c5d6e7f8-a9b0-c1d2-3456-7890e1f2a3b4"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Nissan's Electric Crossover.</h3><p>Experience the future of driving with the all-electric Ariya, blending sleek design with advanced EV technology.</p>", "Nissan's Electric Crossover.\nExperience the future of driving with the all-electric Ariya, blending sleek design with advanced EV technology.\n", false, "Nissan Ariya", 50000m, 10034 },
                    { new Guid("c7d8e9f0-a1b2-c3d4-5678-9012e3f4a5b6"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Luxury Electric Benchmark.</h3><p>The sedan that redefined electric performance, offering incredible acceleration, range, and technology.</p>", "Luxury Electric Benchmark.\nThe sedan that redefined electric performance, offering incredible acceleration, range, and technology.\n", false, "Tesla Model S", 90000m, 10046 },
                    { new Guid("c9d0e1f2-a3b4-c5d6-7890-1234e5f6a7b8"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Family-Friendly Crossover.</h3><p>Nissan's popular compact SUV, offering advanced safety features and a comfortable, versatile interior.</p>", "Family-Friendly Crossover.\nNissan's popular compact SUV, offering advanced safety features and a comfortable, versatile interior.\n", false, "Nissan Rogue", 32000m, 10028 },
                    { new Guid("d0e1f2a3-b4c5-d6e7-8901-2345f6a7b8c9"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Intelligent Midsize Sedan.</h3><p>A stylish sedan featuring available All-Wheel Drive and driver-assist technologies.</p>", "Intelligent Midsize Sedan.\nA stylish sedan featuring available All-Wheel Drive and driver-assist technologies.\n", false, "Nissan Altima", 30000m, 10029 },
                    { new Guid("d2a1b0c9-f8e7-b6a5-d4c3-b2a1d0e9f8e7"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Compact dimensions, grand aspirations.</h3><p>Agile and adventurous, the GLA combines SUV versatility with compact efficiency, perfect for navigating city streets or exploring scenic routes.</p>", "Compact dimensions, grand aspirations.\nAgile and adventurous, the GLA combines SUV versatility with compact efficiency, perfect for navigating city streets or exploring scenic routes.\n", false, "GLA SUV", 49900m, 10006 },
                    { new Guid("d2e3f4a5-b6c7-d8e9-0123-4567f8a9b0c1"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Electric Technology Flagship.</h3><p>A bold vision of the future SAV, featuring sustainable luxury, groundbreaking tech, and exhilarating electric power.</p>", "Electric Technology Flagship.\nA bold vision of the future SAV, featuring sustainable luxury, groundbreaking tech, and exhilarating electric power.\n", false, "BMW iX SAV", 90000m, 10041 },
                    { new Guid("d4e5f6a7-b8c9-d0e1-f234-567890a1b2c3"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Compact Versatility.</h3><p>A stylish and efficient compact SUV offering flexibility for city driving and weekend getaways.</p>", "Compact Versatility.\nA stylish and efficient compact SUV offering flexibility for city driving and weekend getaways.\n", false, "Ford Escape", 35000m, 10023 },
                    { new Guid("d6e7f8a9-b0c1-d2e3-4567-8901f2a3b4c5"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Legendary Performance.</h3><p>The iconic sports car returns, pairing timeless design with thrilling twin-turbo V6 power.</p>", "Legendary Performance.\nThe iconic sports car returns, pairing timeless design with thrilling twin-turbo V6 power.\n", false, "Nissan Z", 45000m, 10035 },
                    { new Guid("d8e9f0a1-b2c3-d4e5-6789-0123f4a5b6c7"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Electric SUV with Falcon Wings.</h3><p>A unique family SUV featuring distinctive Falcon Wing doors, impressive range, and performance.</p>", "Electric SUV with Falcon Wings.\nA unique family SUV featuring distinctive Falcon Wing doors, impressive range, and performance.\n", false, "Tesla Model X", 100000m, 10047 },
                    { new Guid("e1f2a3b4-c5d6-e7f8-9012-3456a7b8c9d0"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Sharp Compact Sedan.</h3><p>Offers unexpected style, standard safety features, and premium feel in the compact sedan class.</p>", "Sharp Compact Sedan.\nOffers unexpected style, standard safety features, and premium feel in the compact sedan class.\n", false, "Nissan Sentra", 25000m, 10030 },
                    { new Guid("e3b2a1d0-c9f8-e7b6-a5d4-c3b2a1d0e9f8"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The future of luxury, electrified.</h3><p>The flagship electric sedan fuses progressive design with pioneering technology and breathtaking performance, setting a new standard for electric mobility.</p>", "The future of luxury, electrified.\nThe flagship electric sedan fuses progressive design with pioneering technology and breathtaking performance, setting a new standard for electric mobility.\n", false, "EQS Sedan", 136000m, 10005 },
                    { new Guid("e3f4a5b6-c7d8-e9f0-1234-5678a9b0c1d2"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>High-Performance Icon.</h3><p>The legendary M3 delivers uncompromising track-ready performance combined with everyday usability.</p>", "High-Performance Icon.\nThe legendary M3 delivers uncompromising track-ready performance combined with everyday usability.\n", false, "BMW M3 Sedan", 80000m, 10042 },
                    { new Guid("e5f6a7b8-c9d0-e1f2-3456-7890a1b2c3d4"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Built Wild.</h3><p>Return of an icon. The Ford Bronco is engineered for rugged off-road capability and adventure.</p>", "Built Wild.\nReturn of an icon. The Ford Bronco is engineered for rugged off-road capability and adventure.\n", false, "Ford Bronco", 42000m, 10024 },
                    { new Guid("e7f8a9b0-c1d2-e3f4-5678-9012a3b4c5d6"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The Ultimate Driving Machine.</h3><p>The quintessential sports sedan, balancing dynamic performance with everyday usability and luxury.</p>", "The Ultimate Driving Machine.\nThe quintessential sports sedan, balancing dynamic performance with everyday usability and luxury.\n", false, "BMW 3 Series Sedan", 50000m, 10036 },
                    { new Guid("e9f0a1b2-c3d4-e5f6-7890-1234a5b6c7d8"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Enhanced Electric Sport Sedan.</h3><p>Takes the Model 3 foundation and adds quicker acceleration, track mode, and sportier tuning.</p>", "Enhanced Electric Sport Sedan.\nTakes the Model 3 foundation and adds quicker acceleration, track mode, and sportier tuning.\n", false, "Tesla Model 3 Performance", 55000m, 10048 },
                    { new Guid("f0a1b2c3-d4e5-f6a7-8901-2345b6c7d8e9"), new Guid("747f6d66-7524-40ca-8494-f65e85b5ee5d"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Beyond Ludicrous Speed.</h3><p>Offers staggering acceleration figures, making it one of the quickest production cars ever built.</p>", "Beyond Ludicrous Speed.\nOffers staggering acceleration figures, making it one of the quickest production cars ever built.\n", false, "Tesla Model S Plaid", 110000m, 10049 },
                    { new Guid("f2a3b4c5-d6e7-f8a9-0123-4567b8c9d0e1"), new Guid("582b8c19-0709-4dae-b7a6-fa0e704dad3c"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Rugged 3-Row SUV.</h3><p>Return to rugged. The Pathfinder offers seating for up to eight and capable performance for family adventures.</p>", "Rugged 3-Row SUV.\nReturn to rugged. The Pathfinder offers seating for up to eight and capable performance for family adventures.\n", false, "Nissan Pathfinder", 40000m, 10031 },
                    { new Guid("f4a3b2c1-d0e9-f8a7-b6c5-d4e3f2a1b0c9"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>The pinnacle of electric luxury SUVs.</h3><p>Experience flagship comfort and groundbreaking technology in an all-electric SUV form, redefining sustainable luxury with space for up to seven.</p>", "The pinnacle of electric luxury SUVs.\nExperience flagship comfort and groundbreaking technology in an all-electric SUV form, redefining sustainable luxury with space for up to seven.\n", false, "EQS SUV", 136000m, 10004 },
                    { new Guid("f4a5b6c7-d8e9-f0a1-2345-6789b0c1d2e3"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Open-Top Freedom.</h3><p>A classic roadster experience with modern BMW performance, agility, and style.</p>", "Open-Top Freedom.\nA classic roadster experience with modern BMW performance, agility, and style.\n", false, "BMW Z4 Roadster", 60000m, 10043 },
                    { new Guid("f6a7b8c9-d0e1-f2a3-4567-8901b2c3d4e5"), new Guid("31d78bd0-0b4f-4e87-b02f-8f66d4ab2845"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Electric Thrills.</h3><p>An all-electric SUV bearing the Mustang name, delivering exhilarating performance and advanced technology.</p>", "Electric Thrills.\nAn all-electric SUV bearing the Mustang name, delivering exhilarating performance and advanced technology.\n", false, "Ford Mustang Mach-E", 55000m, 10025 },
                    { new Guid("f8a9b0c1-d2e3-f4a5-6789-0123b4c5d6e7"), new Guid("ecf0496f-f1e3-4d92-8fe4-0d7fa2b4ffa4"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Versatile Sport Activity Vehicle.</h3><p>Combines dynamic BMW driving characteristics with the versatility and utility of an SAV.</p>", "Versatile Sport Activity Vehicle.\nCombines dynamic BMW driving characteristics with the versatility and utility of an SAV.\n", false, "BMW X3 SAV", 55000m, 10037 },
                    { new Guid("f9f8e7b6-a5d4-c3b2-a1d0-e9f8e7b6a5d4"), new Guid("6fae78f3-b067-40fb-a2d5-9c8dd5eb2e08"), new DateTimeOffset(new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "<h3>Open-air freedom, elegant design.</h3><p>Experience the joy of driving with the top down in the CLE Cabriolet, offering sophisticated style, year-round comfort, and exhilarating performance.</p>", "Open-air freedom, elegant design.\nExperience the joy of driving with the top down in the CLE Cabriolet, offering sophisticated style, year-round comfort, and exhilarating performance.\n", false, "CLE Cabriolet", 75000m, 10019 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "mx-p-s", "-1", new Guid("8ff71671-a1d6-5f97-abb9-d87d7b47d6e7") },
                    { 2, "feat", "3.0", new Guid("9ff71672-a1d5-4f97-abb7-d87d6b47d5e8") },
                    { 3, "feat", "3.1", new Guid("9ff71672-a1d5-4f97-abb7-d87d6b47d5e8") },
                    { 4, "feat", "4.0", new Guid("9ff71672-a1d5-4f97-abb7-d87d6b47d5e8") }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8ff71671-a1d6-5f97-abb9-d87d7b47d6e7"), new Guid("8ff71671-a1d6-4f97-abb9-d87d7b47d6e7") });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "dbo",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HangfireCounter_ExpireAt",
                schema: "jobs",
                table: "HangfireCounter",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireCounter_Key_Value",
                schema: "jobs",
                table: "HangfireCounter",
                columns: new[] { "Key", "Value" });

            migrationBuilder.CreateIndex(
                name: "IX_HangfireHash_ExpireAt",
                schema: "jobs",
                table: "HangfireHash",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireJob_ExpireAt",
                schema: "jobs",
                table: "HangfireJob",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireJob_StateId",
                schema: "jobs",
                table: "HangfireJob",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireJob_StateName",
                schema: "jobs",
                table: "HangfireJob",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireList_ExpireAt",
                schema: "jobs",
                table: "HangfireList",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireQueuedJob_JobId",
                schema: "jobs",
                table: "HangfireQueuedJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireQueuedJob_Queue_FetchedAt",
                schema: "jobs",
                table: "HangfireQueuedJob",
                columns: new[] { "Queue", "FetchedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_HangfireServer_Heartbeat",
                schema: "jobs",
                table: "HangfireServer",
                column: "Heartbeat");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireSet_ExpireAt",
                schema: "jobs",
                table: "HangfireSet",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_HangfireSet_Key_Score",
                schema: "jobs",
                table: "HangfireSet",
                columns: new[] { "Key", "Score" });

            migrationBuilder.CreateIndex(
                name: "IX_HangfireState_JobId",
                schema: "jobs",
                table: "HangfireState",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                schema: "dbo",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShortId",
                schema: "dbo",
                table: "Products",
                column: "ShortId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PushNotificationSubscriptions_UserSessionId",
                schema: "dbo",
                table: "PushNotificationSubscriptions",
                column: "UserSessionId",
                unique: true,
                filter: "[UserSessionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId_ClaimType_ClaimValue",
                schema: "dbo",
                table: "RoleClaims",
                columns: new[] { "RoleId", "ClaimType", "ClaimValue" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "dbo",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPrompts_PromptKind",
                schema: "dbo",
                table: "SystemPrompts",
                column: "PromptKind",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_UserId",
                schema: "dbo",
                table: "TodoItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId_ClaimType_ClaimValue",
                schema: "dbo",
                table: "UserClaims",
                columns: new[] { "UserId", "ClaimType", "ClaimValue" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId_UserId",
                schema: "dbo",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "dbo",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                schema: "dbo",
                table: "UserSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WebAuthnCredential_UserId",
                schema: "dbo",
                table: "WebAuthnCredential",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HangfireJob_HangfireState_StateId",
                schema: "jobs",
                table: "HangfireJob",
                column: "StateId",
                principalSchema: "jobs",
                principalTable: "HangfireState",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangfireJob_HangfireState_StateId",
                schema: "jobs",
                table: "HangfireJob");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HangfireCounter",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireHash",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireJobParameter",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireList",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireLock",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireQueuedJob",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireServer",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireSet",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PushNotificationSubscriptions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SystemPrompts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TodoItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebAuthnCredential",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserSessions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HangfireState",
                schema: "jobs");

            migrationBuilder.DropTable(
                name: "HangfireJob",
                schema: "jobs");

            migrationBuilder.DropSequence(
                name: "ProductShortId",
                schema: "dbo");
        }
    }
}
