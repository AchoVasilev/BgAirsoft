using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class GunChangedPropertiesToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Guns",
                type: "float(14)",
                maxLength: 9999,
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9999);

            migrationBuilder.AlterColumn<double>(
                name: "Power",
                table: "Guns",
                type: "float(14)",
                maxLength: 999,
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 999);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Guns",
                type: "int",
                maxLength: 9999,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldMaxLength: 9999,
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Power",
                table: "Guns",
                type: "int",
                maxLength: 999,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldMaxLength: 999,
                oldPrecision: 14,
                oldScale: 2);
        }
    }
}
