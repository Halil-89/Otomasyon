using Microsoft.Build.Graph;

namespace Otomasyon.Models.Entities
{
    public class KargoDetay
    {
        public int KargoDetayId { get; set; }
        public string Aciklama { get; set; }
        public string TakipKodu { get; set; }
        public string  Personel { get; set; }
        public string Alıcı { get; set; }
        public DateTime Tarih { get; set; }
    }
}
