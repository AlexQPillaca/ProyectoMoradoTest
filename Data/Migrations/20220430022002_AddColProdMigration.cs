using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Data.Migrations
{
    public partial class AddColProdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "t_producto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "t_producto");
        }
    }
}
