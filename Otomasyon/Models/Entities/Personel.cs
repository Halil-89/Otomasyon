using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Otomasyon.Models.Entities
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string PersonelAd { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string PersonelSoyad { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

    }
}
