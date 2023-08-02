using System.ComponentModel.DataAnnotations;


namespace Otomasyon.Models.Entities
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}
