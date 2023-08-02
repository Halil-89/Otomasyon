using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class InitialCatalogDetay1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "UrunDetay");

            migrationBuilder.CreateTable(
                name: "Detay",
                columns: table => new
                {
                    DetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UrunBilgi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detay", x => x.DetayId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Detay");

            migrationBuilder.CreateTable(
                name: "UrunDetay",
                columns: table => new
                {
                    DetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunBilgi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    urunAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunDetay", x => x.DetayId);
                });
        }
    }
}
