using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class InitialCatalogYapilacak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yapilacak",
                columns: table => new
                {
                    YapilacakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yapilacak", x => x.YapilacakId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yapilacak");
        }
    }
}
