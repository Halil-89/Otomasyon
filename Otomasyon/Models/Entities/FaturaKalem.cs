using System.ComponentModel.DataAnnotations;

namespace Otomasyon.Models.Entities
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public int FaturaId { get; set; }
        public Fatura Fatura { get; set; }
    }
}
