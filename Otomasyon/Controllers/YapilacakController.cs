using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class YapilacakController : Controller
    {
        private readonly Context _context;

        public YapilacakController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deger1 = _context.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = _context.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = _context.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in _context.Caris
                          select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;


            var yapilacakalar = _context.Yapilacaks.ToList();


            return View(yapilacakalar);
        }
    }
}
