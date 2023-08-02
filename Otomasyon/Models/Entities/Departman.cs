using System.ComponentModel.DataAnnotations;


namespace Otomasyon.Models.Entities
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        public string DeparmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}
