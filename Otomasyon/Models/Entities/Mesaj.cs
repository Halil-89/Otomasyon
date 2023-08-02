namespace Otomasyon.Models.Entities
{
    public class Mesaj
    {
        public int MesajId { get; set; }
        public string Gönderici { get; set; }
        public string Alici { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}
