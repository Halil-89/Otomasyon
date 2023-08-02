using System.ComponentModel.DataAnnotations;


namespace Otomasyon.Models.Entities
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}
