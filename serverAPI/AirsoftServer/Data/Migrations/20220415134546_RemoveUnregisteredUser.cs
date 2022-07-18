using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveUnregisteredUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UnregisteredClients_UnregisteredClientId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "UnregisteredClients");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UnregisteredClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnregisteredClientId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnregisteredClientId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnregisteredClients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LasttName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnregisteredClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnregisteredClients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UnregisteredClientId",
                table: "Orders",
                column: "UnregisteredClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UnregisteredClients_AddressId",
                table: "UnregisteredClients",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UnregisteredClients_UnregisteredClientId",
                table: "Orders",
                column: "UnregisteredClientId",
                principalTable: "UnregisteredClients",
                principalColumn: "Id");
        }
    }
}
