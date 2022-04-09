using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveImageFromDealer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Images_ImageId",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_ImageId",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Dealers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "LasttName");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Dealers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_ImageId",
                table: "Dealers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Images_ImageId",
                table: "Dealers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
