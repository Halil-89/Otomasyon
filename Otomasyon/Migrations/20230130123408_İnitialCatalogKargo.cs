using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class İnitialCatalogKargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonelGorsel",
                table: "Personel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(230)",
                oldMaxLength: 230);

            migrationBuilder.CreateTable(
                name: "KargoDetay",
                columns: table => new
                {
                    KargoDetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TakipKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Personel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alıcı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoDetay", x => x.KargoDetayId);
                });

            migrationBuilder.CreateTable(
                name: "KargoTakip",
                columns: table => new
                {
                    KargoTakipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakipKodu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TarihZaman = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoTakip", x => x.KargoTakipId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KargoDetay");

            migrationBuilder.DropTable(
                name: "KargoTakip");

            migrationBuilder.AlterColumn<string>(
                name: "PersonelGorsel",
                table: "Personel",
                type: "nvarchar(230)",
                maxLength: 230,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
