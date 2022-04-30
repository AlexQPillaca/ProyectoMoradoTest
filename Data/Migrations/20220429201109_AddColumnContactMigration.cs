using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Data.Migrations
{
    public partial class AddColumnContactMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "t_contacto");
        }
    }
}
