using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventModular.Server.Modules.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.EnsureSchema(
                name: "localization");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RelatedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelatedEntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreviousStatus = table.Column<int>(type: "int", nullable: false),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistory_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductKind = table.Column<int>(type: "int", nullable: false),
                    SnapshotTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnapshotJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLocalization_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNote",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNote_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTracking",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTracking_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemLocalization_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalSchema: "order",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNoteLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNoteLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNoteLocalization_OrderNote_OrderNoteId",
                        column: x => x.OrderNoteId,
                        principalSchema: "order",
                        principalTable: "OrderNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackingLocalization",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackingLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackingLocalization_OrderTracking_OrderTrackingId",
                        column: x => x.OrderTrackingId,
                        principalSchema: "order",
                        principalTable: "OrderTracking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_OrderId",
                schema: "order",
                table: "OrderHistory",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "order",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemLocalization_OrderItemId",
                schema: "localization",
                table: "OrderItemLocalization",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLocalization_OrderId",
                schema: "localization",
                table: "OrderLocalization",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_OrderId",
                schema: "order",
                table: "OrderNote",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNoteLocalization_OrderNoteId",
                schema: "localization",
                table: "OrderNoteLocalization",
                column: "OrderNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_OrderId",
                schema: "order",
                table: "OrderTracking",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackingLocalization_OrderTrackingId",
                schema: "localization",
                table: "OrderTrackingLocalization",
                column: "OrderTrackingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHistory",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderItemLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderNoteLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderTrackingLocalization",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderNote",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderTracking",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "order");
        }
    }
}
