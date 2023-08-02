
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otomasyon.Models.Context;
using Otomasyon.Models.ModelViews;

namespace Otomasyon.Controllers
{
    //[Authorize]
    public class IstatistikController : Controller
    {
        private readonly Context _context;

        public IstatistikController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var deger1 = _context.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = _context.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = _context.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = _context.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = _context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger4;

            var deger6 = (from x in _context.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = _context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in _context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in _context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = _context.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = _context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = _context.Uruns.GroupBy(x => x.Marka).OrderByDescending(a => a.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = _context.Uruns.Where(x => x.UrunId == (_context.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(a => a.Count()).Select(y => y.Key).FirstOrDefault())).Select(x => x.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = _context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = _context.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = _context.SatisHarekets.Where(x => x.Tarih == bugun).Sum(x => x.ToplamTutar).ToString();
            ViewBag.d16 = deger16;


            return View();
        }

        public async Task<IActionResult> KolayTablolar()
        {
            var sorgu = from x in _context.Caris
                        group x by x.CariSehir into g
                        select new SinifGrupViewModel
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }


    }
}
