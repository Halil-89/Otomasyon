using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;
using Otomasyon.Models.ModelViews;

namespace Otomasyon.ViewComponents.Istatistik
{
    public class SınıfGrup5 : ViewComponent
    {
        private readonly Context _context;

        public SınıfGrup5(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var sorgu = from x in _context.Uruns
                        group x by x.Marka into g
                        select new SınıfGrup5ViewModel
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
            // return View();
        }

    }
}
