using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class model4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Products",
                newName: "ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                newName: "IX_Products_ShopID");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopID",
                table: "Products",
                column: "ShopID",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShopID",
                table: "Products",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopID",
                table: "Products",
                newName: "IX_Products_ShopId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
