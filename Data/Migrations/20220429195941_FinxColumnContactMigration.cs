using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Data.Migrations
{
    public partial class FinxColumnContactMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "subject",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment",
                table: "t_contacto");

            migrationBuilder.DropColumn(
                name: "email",
                table: "t_contacto");

            migrationBuilder.DropColumn(
                name: "subject",
                table: "t_contacto");
        }
    }
}
