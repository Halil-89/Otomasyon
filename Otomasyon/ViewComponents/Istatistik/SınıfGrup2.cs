using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;
using Otomasyon.Models.ModelViews;

namespace Otomasyon.ViewComponents.Istatistik
{
    public class SınıfGrup2 : ViewComponent
    {
        private readonly Context _context;

        public SınıfGrup2(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var sorgu2 = from x in _context.Personels
                         group x by x.Departman.DeparmanAd into g
                         select new SınıfGrup2ViewModel
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return View(sorgu2.ToList());
        }
    }
}
