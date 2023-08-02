using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;

namespace Otomasyon.Controllers
{
    //[Authorize]
    public class GaleriController : Controller
    {
        private readonly Context _context;

        public GaleriController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Uruns.ToListAsync();
            return View(urunler);
        }
    }
}
