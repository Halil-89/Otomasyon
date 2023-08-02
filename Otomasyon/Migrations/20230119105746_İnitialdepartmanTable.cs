using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class İnitialdepartmanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "Departman",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Departman");
        }
    }
}
