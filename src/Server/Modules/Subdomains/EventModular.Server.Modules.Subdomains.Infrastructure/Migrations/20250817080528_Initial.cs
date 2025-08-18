using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Subdomains.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "subdomain");

            migrationBuilder.EnsureSchema(
                name: "localization");

            migrationBuilder.CreateTable(
                name: "Subdomain",
                schema: "subdomain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdomain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubdomainLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubdomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubdomainLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubdomainLocalization_Subdomain_SubdomainId",
                        column: x => x.SubdomainId,
                        principalSchema: "subdomain",
                        principalTable: "Subdomain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubdomainSubscriptionHistory",
                schema: "subdomain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubdomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubdomainSubscriptionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubdomainSubscriptionHistory_Subdomain_SubdomainId",
                        column: x => x.SubdomainId,
                        principalSchema: "subdomain",
                        principalTable: "Subdomain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubdomainLocalization_SubdomainId",
                schema: "localization",
                table: "SubdomainLocalization",
                column: "SubdomainId");

            migrationBuilder.CreateIndex(
                name: "IX_SubdomainSubscriptionHistory_SubdomainId",
                schema: "subdomain",
                table: "SubdomainSubscriptionHistory",
                column: "SubdomainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubdomainLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "SubdomainSubscriptionHistory",
                schema: "subdomain");

            migrationBuilder.DropTable(
                name: "Subdomain",
                schema: "subdomain");
        }
    }
}
