using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Notifications.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "notification");

            migrationBuilder.EnsureSchema(
                name: "localization");

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedOwnerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelatedOwnerType = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DataJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationLocalization_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "notification",
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLocalization_NotificationId",
                schema: "localization",
                table: "NotificationLocalization",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "notification");
        }
    }
}
