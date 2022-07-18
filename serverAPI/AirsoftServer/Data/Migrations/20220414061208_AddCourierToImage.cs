using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddCourierToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourierId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CourierId",
                table: "Images",
                column: "CourierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Couriers_CourierId",
                table: "Images",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Couriers_CourierId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CourierId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "Images");
        }
    }
}
