using System.ComponentModel.DataAnnotations;


namespace Otomasyon.Models.Entities
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
        //[Column(TypeName = "Char")]
        //[StringLength(1)]
        public string FaturaSeriNo { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(60)]
        public string VergiDairesi { get; set; }
        public string Saat { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string TeslimAlan { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string TeslimEden { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}
