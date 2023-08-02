using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otomasyon.Models.Entities;
using System.Reflection.Emit;

namespace Otomasyon.Models.EntityConfiguration
{
    public class Configuration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.AdminId);
            builder.Property(x => x.KullaniciAd).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Sifre).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Yetki).IsRequired().HasMaxLength(1);
            builder.ToTable("Admin");
        }
    }

    public class CariConfiguration : IEntityTypeConfiguration<Cari>
    {
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            builder.HasKey(x => x.CariId);
            builder.Property(x => x.CariAd).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CariSoyad).IsRequired().HasMaxLength(13);
            builder.Property(x => x.CariSehir).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CariSehir).IsRequired().HasMaxLength(20);
            builder.ToTable("Cari");
        }
    }

    public class DepartmanConfiguration : IEntityTypeConfiguration<Departman>
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.HasKey(x => x.DepartmanId);
            builder.Property(x => x.DeparmanAd).IsRequired().HasMaxLength(30);
            builder.ToTable("Departman");

        }
    }

    public class FaturanConfiguration : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(x => x.FaturaId);
            builder.Property(x => x.FaturaSeriNo).IsRequired().HasMaxLength(6);
            builder.Property(x => x.FaturaSıraNo).IsRequired().HasMaxLength(6);
            builder.Property(x => x.VergiDairesi).IsRequired().HasMaxLength(60);
            builder.Property(x => x.TeslimAlan).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Saat).IsRequired().HasMaxLength(5);
            builder.Property(x => x.TeslimEden).IsRequired().HasMaxLength(60);
            builder.ToTable("Fatura");

        }
    }

    public class FaturaKalemConfiguration : IEntityTypeConfiguration<FaturaKalem>
    {
        public void Configure(EntityTypeBuilder<FaturaKalem> builder)
        {
            builder.HasOne(x => x.Fatura).WithMany(x => x.FaturaKalems).HasForeignKey(x => x.FaturaId);
            //builder.HasKey(x => x.FaturaKalemId);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(60);
            builder.ToTable("FaturaKalem");


        }
    }

    public class GiderConfiguration : IEntityTypeConfiguration<Gider>
    {
        public void Configure(EntityTypeBuilder<Gider> builder)
        {
            builder.HasKey(x => x.GiderId);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(60);
            builder.ToTable("Gider");


        }
    }

    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(x => x.KategoriId);
            builder.Property(x => x.KategoriAd).IsRequired().HasMaxLength(30);
            builder.ToTable("Kategori");


        }
    }

    public class PersonelConfiguration : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasKey(x => x.PersonelId);
            builder.Property(x => x.PersonelAd).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PersonelSoyad).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PersonelGorsel).IsRequired();
            builder.ToTable("Personel");


        }
    }

    public class SatisHareketConfiguration : IEntityTypeConfiguration<SatisHareket>
    {
        public void Configure(EntityTypeBuilder<SatisHareket> builder)
        {
            builder.HasKey(x => x.SatisId);
            builder.ToTable("SatisHareket");



        }
    }
    public class UrunConfiguration : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasKey(x => x.UrunId);
            builder.Property(x => x.UrunAd).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Marka).IsRequired().HasMaxLength(30);
            builder.Property(x => x.UrunGorsel).IsRequired().HasMaxLength(230);
            builder.ToTable("Urun");


        }
    }

    public class UrunDetayConfiguration : IEntityTypeConfiguration<Detay>
    {
        public void Configure(EntityTypeBuilder<Detay> builder)
        {
            builder.HasKey(x => x.DetayId);
            builder.Property(x => x.UrunBilgi).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.urunAd).IsRequired().HasMaxLength(30);


            builder.ToTable("Detay");


        }
    }

    public class YapilacakConfiguration : IEntityTypeConfiguration<Yapilacak>
    {
        public void Configure(EntityTypeBuilder<Yapilacak> builder)
        {
            builder.HasKey(x => x.YapilacakId);
            builder.Property(x => x.Baslik).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Durum).IsRequired();


            builder.ToTable("Yapilacak");


        }
    }

    public class KargoTakipConfiguration : IEntityTypeConfiguration<KargoTakip>
    {
        public void Configure(EntityTypeBuilder<KargoTakip> builder)
        {
            builder.HasKey(x => x.KargoTakipId);
            builder.Property(x => x.TakipKodu).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(100);


            builder.ToTable("KargoTakip");


        }
    }

    public class KargoDetayConfiguration : IEntityTypeConfiguration<KargoDetay>
    {
        public void Configure(EntityTypeBuilder<KargoDetay> builder)
        {
            builder.HasKey(x => x.KargoDetayId);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(300);
            builder.Property(x => x.TakipKodu).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Alıcı).IsRequired().HasMaxLength(20);


            builder.ToTable("KargoDetay");


        }
    }

    public class MesajConfiguration : IEntityTypeConfiguration<Mesaj>
    {
        public void Configure(EntityTypeBuilder<Mesaj> builder)
        {
            builder.HasKey(x => x.MesajId);
            builder.Property(x => x.Gönderici).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Alici).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Konu).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Icerik).IsRequired().HasMaxLength(2000);


            builder.ToTable("Mesaj");


        }
    }
}
