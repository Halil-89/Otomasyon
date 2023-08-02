using FluentValidation;
using Otomasyon.Models.Entities;

namespace Otomasyon.ValidationRules
{
    public class CariValidations : AbstractValidator<Cari>
    {
        public CariValidations()
        {
            RuleFor(x => x.CariAd).NotEmpty().WithMessage("Cari Ad Boş Geçilemez");
            RuleFor(x => x.CariAd).MaximumLength(30).WithMessage("Cari Adı Uzunlugu en fazla 30 karakter olmalıdır");
            RuleFor(x => x.CariSoyad).NotEmpty().WithMessage("Cari Soyad Boş GEçilemez");
            RuleFor(x => x.CariSoyad).MaximumLength(13).WithMessage("Cari Adı Uzunlugu en fazla 13 karakter olmalıdır");
            RuleFor(x => x.CariSehir).NotEmpty().WithMessage("Cari Şehir Boş GEçilemez");
            RuleFor(x => x.CariSehir).MaximumLength(20).WithMessage("Cari Şehir Uzunlugu en fazla 20 karakter olmalıdır");
            RuleFor(x => x.CariMail).NotEmpty().WithMessage("Cari Mail Boş GEçilemez");
            RuleFor(x => x.CariMail).MaximumLength(30).WithMessage("Cari Mail Uzunlugu en fazla 30 karakter olmalıdır");

        }

    }

    public class DepartmanValidations : AbstractValidator<Departman>
    {
        public DepartmanValidations()
        {
            RuleFor(x => x.DeparmanAd).NotEmpty().WithMessage("Departman Ad Boş Geçilemez");
            RuleFor(x => x.DeparmanAd).MaximumLength(30).WithMessage("Departman Adı Uzunlugu en fazla 30 karakter olmalıdır");

        }

    }

    public class KategoriValidations : AbstractValidator<Kategori>
    {
        public KategoriValidations()
        {
            RuleFor(x => x.KategoriAd).NotEmpty().WithMessage("Kategori Ad Boş Geçilemez");
            RuleFor(x => x.KategoriAd).MaximumLength(30).WithMessage("Kategori Adı Uzunlugu en fazla 30 karakter olmalıdır");

        }

    }

    public class UrunValidations : AbstractValidator<Urun>
    {
        public UrunValidations()
        {
            RuleFor(x => x.UrunAd).NotEmpty().WithMessage("Ürün Ad Boş Geçilemez");
            RuleFor(x => x.UrunAd).MaximumLength(30).WithMessage("Ürün Adı Uzunlugu en fazla 30 karakter olmalıdır");
            RuleFor(x => x.Marka).NotEmpty().WithMessage("MArka Ad Boş Geçilemez");
            RuleFor(x => x.Marka).MaximumLength(30).WithMessage("Marka Adı Uzunlugu en fazla 30 karakter olmalıdır");
            RuleFor(x => x.UrunGorsel).NotEmpty().WithMessage("Ürün Görsel Ad Boş Geçilemez");
            RuleFor(x => x.UrunGorsel).MaximumLength(30).WithMessage("Ürün Görsel Adı Uzunlugu en fazla 230 karakter olmalıdır");
            RuleFor(x => x.Stok).NotEmpty().WithMessage("Ürün Stok Ad Boş Geçilemez");
            RuleFor(x => x.AlisFiyat).NotEmpty().WithMessage("Ürün AlışFiyat Ad Boş Geçilemez");
            RuleFor(x => x.SatisFiyat).NotEmpty().WithMessage("Ürün SatışFiyat Ad Boş Geçilemez");
            //RuleFor(x => x.Durum).NotEmpty().WithMessage("Ürün Durum Ad Boş Geçilemez");
            RuleFor(x => x.Durum).Must(x => x == true || x == false);

        }

    }

    public class PersonelValidations : AbstractValidator<Personel>
    {
        public PersonelValidations()
        {
            RuleFor(x => x.PersonelAd).NotEmpty().WithMessage("Personel Ad Boş Geçilemez");
            RuleFor(x => x.PersonelAd).MaximumLength(30).WithMessage("Personel Adı Uzunlugu en fazla 30 karakter olmalıdır");
            RuleFor(x => x.PersonelSoyad).NotEmpty().WithMessage("Personel Soyad Boş GEçilemez");
            RuleFor(x => x.PersonelSoyad).MaximumLength(13).WithMessage("Personel Soyad Uzunlugu en fazla 13 karakter olmalıdır");
            //RuleFor(x => x.PersonelGorsel).NotEmpty().WithMessage("Personel Görsel Boş GEçilemez");
            //RuleFor(x => x.PersonelGorsel).MaximumLength(230).WithMessage("Personel Görsel Uzunlugu en fazla 230 karakter olmalıdır");
            RuleFor(x => x.DepartmanId).NotEmpty().WithMessage("DepartmanId Boş GEçilemez");


        }

    }

    public class SatisValidations : AbstractValidator<SatisHareket>
    {
        public SatisValidations()
        {
            //RuleFor(x => x.Tarih).NotEmpty().WithMessage("Tarih Boş Geçilemez");
            RuleFor(x => x.Adet).NotEmpty().NotNull().WithMessage("Adet Boş GEçilemez");
            RuleFor(x => x.Fiyat).NotEmpty().NotNull().WithMessage("Fiyat Boş GEçilemez");
            RuleFor(x => x.ToplamTutar).NotEmpty().NotNull().WithMessage("Toplam Boş GEçilemez");

            RuleFor(x => x.UrunId).NotEmpty().WithMessage("UrunId Boş GEçilemez");
            RuleFor(x => x.UrunId).NotEqual(0).WithMessage("Lütfen Urun Seçiniz");

            RuleFor(x => x.CariId).NotEmpty().WithMessage("CariId Boş GEçilemez");
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage("PersonelId Boş GEçilemez");


        }

    }

    public class FaturaValidations : AbstractValidator<Fatura>
    {
        public FaturaValidations()
        {

            //RuleFor(x => x.FaturaId).NotEmpty().NotNull().WithMessage("Fatura ID Boş GEçilemez");
            RuleFor(x => x.FaturaSeriNo).NotEmpty().NotNull().WithMessage("Fatura Seri No Boş GEçilemez");
            RuleFor(x => x.FaturaSıraNo).NotEmpty().NotNull().WithMessage("Fatura Sıra No Boş GEçilemez");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("Tarih Boş GEçilemez");
            //RuleFor(x => x.Toplam).NotEmpty().WithMessage("Toplam Boş GEçilemez");

            RuleFor(x => x.VergiDairesi).NotEmpty().WithMessage("Vergi Dairesi Boş Geçilemez");
            RuleFor(x => x.VergiDairesi).MaximumLength(60).WithMessage("Personel Görsel Uzunlugu en fazla 230 karakter olmalıdır");

            RuleFor(x => x.TeslimAlan).NotEmpty().WithMessage("Vergi Dairesi Boş Geçilemez");
            RuleFor(x => x.TeslimAlan).MaximumLength(60).WithMessage("Personel Görsel Uzunlugu en fazla 230 karakter olmalıdır");

            RuleFor(x => x.TeslimEden).NotEmpty().WithMessage("Vergi Dairesi Boş Geçilemez");
            RuleFor(x => x.TeslimEden).MaximumLength(60).WithMessage("Personel Görsel Uzunlugu en fazla 230 karakter olmalıdır");




        }

    }

    public class FaturaKalemValidations : AbstractValidator<FaturaKalem>
    {
        public FaturaKalemValidations()
        {


            RuleFor(x => x.Miktar).NotEmpty().NotNull().WithMessage("Miktar Seri No Boş GEçilemez");
            RuleFor(x => x.Tutar).NotEmpty().NotNull().WithMessage("Tutar Sıra No Boş GEçilemez");
            RuleFor(x => x.FaturaId).NotEmpty().WithMessage("FaturaId Boş GEçilemez");


            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.Aciklama).MaximumLength(60).WithMessage("Acıklama Uzunlugu en fazla 60 karakter olmalıdır");



        }

    }

    public class KargoDetayValidations : AbstractValidator<KargoDetay>
    {
        public KargoDetayValidations()
        {
            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Acıklama Ad Boş Geçilemez");
            RuleFor(x => x.Aciklama).MaximumLength(20).WithMessage("Acıklama Uzunlugu en fazla 300 karakter olmalıdır");

            RuleFor(x => x.TakipKodu).NotEmpty().WithMessage("Takip Kodu Ad Boş Geçilemez");
            RuleFor(x => x.TakipKodu).MaximumLength(20).WithMessage("Takipkodu Uzunlugu en fazla 300 karakter olmalıdır");

            RuleFor(x => x.Personel).NotEmpty().WithMessage("Personel Ad Boş Geçilemez");
            RuleFor(x => x.Personel).MaximumLength(20).WithMessage("Personel  Uzunlugu en fazla 20 karakter olmalıdır");

            RuleFor(x => x.Alıcı).NotEmpty().WithMessage("Alıcı Ad Boş Geçilemez");
            RuleFor(x => x.Alıcı).MaximumLength(20).WithMessage("Alıcı Uzunlugu en fazla 20 karakter olmalıdır");

            RuleFor(x => x.Tarih).NotEmpty().WithMessage("Tarih  Boş Geçilemez");

        }

    }

    public class MesajValidations : AbstractValidator<Mesaj>
    {
        public MesajValidations()
        {
            RuleFor(x => x.Alici).NotEmpty().WithMessage("Alıcı  Boş Geçilemez");
            RuleFor(x => x.Alici).MaximumLength(50).WithMessage("Alıcı Adı Uzunlugu en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Gönderici).NotEmpty().WithMessage("Gönderici  Boş Geçilemez");
            RuleFor(x => x.Gönderici).MaximumLength(50).WithMessage("Gönderici Adı Uzunlugu en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Konu).NotEmpty().WithMessage("Konu  Boş Geçilemez");
            RuleFor(x => x.Konu).MaximumLength(30).WithMessage("Konu Adı Uzunlugu en fazla 30 karakter olmalıdır");

            RuleFor(x => x.Icerik).NotEmpty().WithMessage("İçerik  Boş Geçilemez");
            RuleFor(x => x.Icerik).MaximumLength(2000).WithMessage(";çerik Adı Uzunlugu en fazla 2000 karakter olmalıdır");


        }

    }
}
