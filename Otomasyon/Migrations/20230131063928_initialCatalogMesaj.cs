using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class initialCatalogMesaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesaj",
                columns: table => new
                {
                    MesajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gönderici = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alici = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesaj", x => x.MesajId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesaj");
        }
    }
}
