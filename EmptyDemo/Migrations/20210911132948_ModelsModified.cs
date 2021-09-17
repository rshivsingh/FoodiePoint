using Microsoft.EntityFrameworkCore.Migrations;

namespace EmptyDemo.Migrations
{
    public partial class ModelsModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscPer",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscAvail",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVeg",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemid);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "Contents", "IsSpecial", "IsVeg" },
                values: new object[] { "abc, xyz", true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                columns: new[] { "Contents", "IsSpecial", "IsVeg" },
                values: new object[] { "abc, xyz", true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                columns: new[] { "Contents", "DiscPer", "IsDiscAvail", "IsVeg" },
                values: new object[] { "abc, xyz", 5, true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4,
                columns: new[] { "Contents", "DiscPer", "IsDiscAvail", "IsSpecial", "IsVeg" },
                values: new object[] { "abc, xyz", 8, true, true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                columns: new[] { "Contents", "IsVeg", "ItemName" },
                values: new object[] { "abc, xyz", true, "abc, xyz" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6,
                columns: new[] { "Contents", "IsSpecial" },
                values: new object[] { "abc, xyz", true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7,
                columns: new[] { "Contents", "IsSpecial", "IsVeg" },
                values: new object[] { "abc, xyz", true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8,
                columns: new[] { "Contents", "DiscPer", "IsDiscAvail", "IsSpecial", "IsVeg" },
                values: new object[] { "abc, xyz", 4, true, true, true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9,
                columns: new[] { "Contents", "DiscPer", "IsDiscAvail", "IsVeg" },
                values: new object[] { "abc, xyz", 10, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ItemId",
                table: "ShoppingCartItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Contents",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DiscPer",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsDiscAvail",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsVeg",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "ItemName",
                value: "Sicilian Pizza");
        }
    }
}
