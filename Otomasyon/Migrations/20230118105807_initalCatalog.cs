using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otomasyon.Migrations
{
    public partial class initalCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Yetki = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Cari",
                columns: table => new
                {
                    CariId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CariSoyad = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CariSehir = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CariMail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cari", x => x.CariId);
                });

            migrationBuilder.CreateTable(
                name: "Departman",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeparmanAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departman", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaSeriNo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FaturaSıraNo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimAlan = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TeslimEden = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.FaturaId);
                });

            migrationBuilder.CreateTable(
                name: "Gider",
                columns: table => new
                {
                    GiderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gider", x => x.GiderId);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PersonelGorsel = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personel_Departman_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departman",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaKalem",
                columns: table => new
                {
                    FaturaKalemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaKalem", x => x.FaturaKalemId);
                    table.ForeignKey(
                        name: "FK_FaturaKalem_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "FaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Stok = table.Column<short>(type: "smallint", nullable: false),
                    AlisFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    UrunGorsel = table.Column<string>(type: "nvarchar(230)", maxLength: 230, nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatisHareket",
                columns: table => new
                {
                    SatisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisHareket", x => x.SatisId);
                    table.ForeignKey(
                        name: "FK_SatisHareket_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "CariId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisHareket_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisHareket_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalem_FaturaId",
                table: "FaturaKalem",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_DepartmanId",
                table: "Personel",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHareket_CariId",
                table: "SatisHareket",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHareket_PersonelId",
                table: "SatisHareket",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHareket_UrunId",
                table: "SatisHareket",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "FaturaKalem");

            migrationBuilder.DropTable(
                name: "Gider");

            migrationBuilder.DropTable(
                name: "SatisHareket");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Cari");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Departman");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
