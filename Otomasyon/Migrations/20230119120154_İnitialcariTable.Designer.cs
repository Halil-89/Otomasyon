﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Otomasyon.Models.Context;

#nullable disable

namespace Otomasyon.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230119120154_İnitialcariTable")]
    partial class İnitialcariTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Otomasyon.Models.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("KullaniciAd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Yetki")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Cari", b =>
                {
                    b.Property<int>("CariId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CariId"), 1L, 1);

                    b.Property<string>("CariAd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CariMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CariSehir")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CariSoyad")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("CariId");

                    b.ToTable("Cari", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Departman", b =>
                {
                    b.Property<int>("DepartmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmanId"), 1L, 1);

                    b.Property<string>("DeparmanAd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.HasKey("DepartmanId");

                    b.ToTable("Departman", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Fatura", b =>
                {
                    b.Property<int>("FaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaturaId"), 1L, 1);

                    b.Property<string>("FaturaSeriNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("FaturaSıraNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeslimAlan")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("TeslimEden")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("VergiDairesi")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("FaturaId");

                    b.ToTable("Fatura", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.FaturaKalem", b =>
                {
                    b.Property<int>("FaturaKalemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaturaKalemId"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FaturaId")
                        .HasColumnType("int");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FaturaKalemId");

                    b.HasIndex("FaturaId");

                    b.ToTable("FaturaKalem", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Gider", b =>
                {
                    b.Property<int>("GiderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiderId"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GiderId");

                    b.ToTable("Gider", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"), 1L, 1);

                    b.Property<string>("KategoriAd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategori", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Personel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelId"), 1L, 1);

                    b.Property<int>("DepartmanId")
                        .HasColumnType("int");

                    b.Property<string>("PersonelAd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PersonelGorsel")
                        .IsRequired()
                        .HasMaxLength(230)
                        .HasColumnType("nvarchar(230)");

                    b.Property<string>("PersonelSoyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PersonelId");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Personel", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.SatisHareket", b =>
                {
                    b.Property<int>("SatisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SatisId"), 1L, 1);

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("CariId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ToplamTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("SatisId");

                    b.HasIndex("CariId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("UrunId");

                    b.ToTable("SatisHareket", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunId"), 1L, 1);

                    b.Property<decimal>("AlisFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("SatisFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Stok")
                        .HasColumnType("smallint");

                    b.Property<string>("UrunAd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UrunGorsel")
                        .IsRequired()
                        .HasMaxLength(230)
                        .HasColumnType("nvarchar(230)");

                    b.HasKey("UrunId");

                    b.HasIndex("KategoriId");

                    b.ToTable("Urun", (string)null);
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.FaturaKalem", b =>
                {
                    b.HasOne("Otomasyon.Models.Entities.Fatura", "Fatura")
                        .WithMany("FaturaKalems")
                        .HasForeignKey("FaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fatura");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Personel", b =>
                {
                    b.HasOne("Otomasyon.Models.Entities.Departman", "Departman")
                        .WithMany("Personels")
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departman");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.SatisHareket", b =>
                {
                    b.HasOne("Otomasyon.Models.Entities.Cari", "Cari")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Otomasyon.Models.Entities.Personel", "Personel")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Otomasyon.Models.Entities.Urun", "Urun")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cari");

                    b.Navigation("Personel");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Urun", b =>
                {
                    b.HasOne("Otomasyon.Models.Entities.Kategori", "Kategori")
                        .WithMany("Uruns")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Cari", b =>
                {
                    b.Navigation("SatisHarekets");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Departman", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Fatura", b =>
                {
                    b.Navigation("FaturaKalems");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Kategori", b =>
                {
                    b.Navigation("Uruns");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Personel", b =>
                {
                    b.Navigation("SatisHarekets");
                });

            modelBuilder.Entity("Otomasyon.Models.Entities.Urun", b =>
                {
                    b.Navigation("SatisHarekets");
                });
#pragma warning restore 612, 618
        }
    }
}
