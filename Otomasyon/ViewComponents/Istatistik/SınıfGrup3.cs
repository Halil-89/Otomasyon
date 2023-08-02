using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;

namespace Otomasyon.ViewComponents.Istatistik
{

    public class SınıfGrup3 : ViewComponent
    {
        private readonly Context _context;

        public SınıfGrup3(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var cariler = _context.Caris.ToList();

            return View(cariler);
        }
    }
}
