using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class InitialCatalogUrunDetay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Detay",
            //    table: "UrunDetay");

            //migrationBuilder.RenameTable(
            //    name: "Detay",
            //    newName: "UrunDetay");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_UrunDetay",
            //    table: "UrunDetay",
            //    column: "DetayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunDetay",
                table: "UrunDetay");

            migrationBuilder.RenameTable(
                name: "UrunDetay",
                newName: "Detay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detay",
                table: "Detay",
                column: "DetayId");
        }
    }
}
