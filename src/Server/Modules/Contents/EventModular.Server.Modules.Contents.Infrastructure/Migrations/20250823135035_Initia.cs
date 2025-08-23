using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Contents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Content");

            migrationBuilder.EnsureSchema(
                name: "Localization");

            migrationBuilder.CreateTable(
                name: "Content",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ContentAllowingStatus = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentLocalization",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentLocalization_Content_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "Content",
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLessonContent",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLessonContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLessonContent_Content_Id",
                        column: x => x.Id,
                        principalSchema: "Content",
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventContent",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventContent_Content_Id",
                        column: x => x.Id,
                        principalSchema: "Content",
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostContent",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContent_Content_Id",
                        column: x => x.Id,
                        principalSchema: "Content",
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostContentLocalization",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Excerpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentLocalization_PostContent_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "Content",
                        principalTable: "PostContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentLocalization_ContentId",
                schema: "Localization",
                table: "ContentLocalization",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContentLocalization_ContentId",
                schema: "Localization",
                table: "PostContentLocalization",
                column: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentLocalization",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "CourseLessonContent",
                schema: "Content");

            migrationBuilder.DropTable(
                name: "EventContent",
                schema: "Content");

            migrationBuilder.DropTable(
                name: "PostContentLocalization",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "PostContent",
                schema: "Content");

            migrationBuilder.DropTable(
                name: "Content",
                schema: "Content");
        }
    }
}
