using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ValidationInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectronicComponents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "ElectronicComponents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "ElectronicComponents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ElectronicComponents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "ElectronicComponents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ElectronicComponents",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreSymbol",
                table: "ElectronicComponents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "ElectronicComponents");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ElectronicComponents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ElectronicComponents");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "ElectronicComponents");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ElectronicComponents");

            migrationBuilder.DropColumn(
                name: "StoreSymbol",
                table: "ElectronicComponents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectronicComponents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
