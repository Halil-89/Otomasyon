using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.ModelViews;

namespace Otomasyon.Controllers
{
    //[Authorize]
    public class UrunDetayController : Controller
    {
        private readonly Context _context;

        public UrunDetayController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            UrunDetayViewModel cs = new UrunDetayViewModel();
            //var urunDetay = await _context.Uruns.Where(x => x.UrunId == 1).ToListAsync();
            cs.Deger1 = await _context.Uruns.Where(x => x.UrunId == 2).ToListAsync();
            cs.Deger2 = await _context.Detays.Where(x => x.DetayId == 1).ToListAsync();
            return View(cs);
        }
    }
}
