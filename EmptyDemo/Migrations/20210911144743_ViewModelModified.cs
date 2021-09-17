using Microsoft.EntityFrameworkCore.Migrations;

namespace EmptyDemo.Migrations
{
    public partial class ViewModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemRef",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemRef",
                table: "ShoppingCartItems");
        }
    }
}
