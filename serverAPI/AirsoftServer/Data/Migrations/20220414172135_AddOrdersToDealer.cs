using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddOrdersToDealer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Orders_OrderId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_OrderId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Dealers");

            migrationBuilder.CreateTable(
                name: "DealerOrder",
                columns: table => new
                {
                    DealersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerOrder", x => new { x.DealersId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DealerOrder_Dealers_DealersId",
                        column: x => x.DealersId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealerOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealerOrder_OrdersId",
                table: "DealerOrder",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerOrder");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Dealers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_OrderId",
                table: "Dealers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Orders_OrderId",
                table: "Dealers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
