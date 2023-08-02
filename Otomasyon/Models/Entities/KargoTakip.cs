namespace Otomasyon.Models.Entities
{
    public class KargoTakip
    {
        public int KargoTakipId{ get; set; }
        public string  TakipKodu { get; set;}
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}
