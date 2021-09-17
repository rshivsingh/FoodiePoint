using Microsoft.EntityFrameworkCore.Migrations;

namespace EmptyDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryListCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_categoryListCategoryId",
                        column: x => x.categoryListCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Dessert" },
                    { 2, "Ice Cream" },
                    { 3, "Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ImageURL", "ItemDescription", "ItemName", "Price", "categoryListCategoryId" },
                values: new object[,]
                {
                    { 1, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Apple Pie", 200, null },
                    { 2, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Almond Malai Kulfi", 150, null },
                    { 3, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Lemon Tart", 200, null },
                    { 4, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Neapolitan Pizza", 200, null },
                    { 5, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Sicilian Pizza", 150, null },
                    { 6, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Detroit Pizza", 200, null },
                    { 7, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Ben & Jerry's Chocolate Brownie Fudge", 200, null },
                    { 8, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Häagen-Dazs Vanilla", 150, null },
                    { 9, null, "Classic for a get-together and you might not have any leftovers to bring home.", "Dove Mint Chocolate Chip Ice Cream", 200, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_categoryListCategoryId",
                table: "Items",
                column: "categoryListCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
