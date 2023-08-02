

using System.ComponentModel.DataAnnotations;

namespace Otomasyon.Models.Entities
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        public string CariAd { get; set; }

        public string CariSoyad { get; set; }

        public string CariSehir { get; set; }

        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public string CariSifre { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}
