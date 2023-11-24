using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndShopingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicComponentProject_Projects_ProjectId",
                table: "ElectronicComponentProject");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ElectronicComponentProject",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicComponentProject_ProjectId",
                table: "ElectronicComponentProject",
                newName: "IX_ElectronicComponentProject_ProjectsId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicComponentShoppingList",
                columns: table => new
                {
                    ElectronicComponentsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicComponentShoppingList", x => new { x.ElectronicComponentsId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_ElectronicComponentShoppingList_ElectronicComponents_ElectronicComponentsId",
                        column: x => x.ElectronicComponentsId,
                        principalTable: "ElectronicComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectronicComponentShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicComponentShoppingList_ShoppingListsId",
                table: "ElectronicComponentShoppingList",
                column: "ShoppingListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicComponentProject_Projects_ProjectsId",
                table: "ElectronicComponentProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicComponentProject_Projects_ProjectsId",
                table: "ElectronicComponentProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ElectronicComponentShoppingList");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ElectronicComponentProject",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicComponentProject_ProjectsId",
                table: "ElectronicComponentProject",
                newName: "IX_ElectronicComponentProject_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicComponentProject_Projects_ProjectId",
                table: "ElectronicComponentProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
