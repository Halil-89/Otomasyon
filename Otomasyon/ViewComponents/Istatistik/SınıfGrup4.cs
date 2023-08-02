using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;

namespace Otomasyon.ViewComponents.Istatistik
{
    public class SınıfGrup4 : ViewComponent
    {
        private readonly Context _context;

        public SınıfGrup4(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var urunler = _context.Uruns.ToList();

            return View(urunler);
            //return View();
        }
    }
}
