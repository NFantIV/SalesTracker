using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntityChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Order_OrderEntityId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderEntityId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemEntityOrderEntity",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntityOrderEntity", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_ItemEntityOrderEntity_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEntityOrderEntity_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntityOrderEntity_OrdersId",
                table: "ItemEntityOrderEntity",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEntityOrderEntity");

            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderEntityId",
                table: "Items",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Order_OrderEntityId",
                table: "Items",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
