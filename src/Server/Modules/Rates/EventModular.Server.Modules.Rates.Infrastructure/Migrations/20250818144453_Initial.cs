using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Rates.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rate");

            migrationBuilder.CreateTable(
                name: "Rate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRate_Rate_RateId",
                        column: x => x.RateId,
                        principalSchema: "Rate",
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRate_Rate_RateId",
                        column: x => x.RateId,
                        principalSchema: "Rate",
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRate_Rate_RateId",
                        column: x => x.RateId,
                        principalSchema: "Rate",
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostRate_Rate_RateId",
                        column: x => x.RateId,
                        principalSchema: "Rate",
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRate_RateId",
                schema: "Rate",
                table: "CommentRate",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRate_RateId",
                schema: "Rate",
                table: "CourseRate",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRate_RateId",
                schema: "Rate",
                table: "EventRate",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRate_RateId",
                schema: "Rate",
                table: "PostRate",
                column: "RateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "CourseRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "EventRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "PostRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "Rate",
                schema: "Rate");
        }
    }
}
