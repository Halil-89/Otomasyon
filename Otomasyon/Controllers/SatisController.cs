
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;

namespace Otomasyon.Controllers
{
  //  [Authorize]
    public class SatisController : Controller
    {
        private readonly Context _context;

        public SatisController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var satislar = await _context.SatisHarekets.Include(p => p.Urun).Include(a => a.Cari).Include(c => c.Personel).ToListAsync();
            return View(satislar);
        }
        [HttpGet]
        public async Task<IActionResult> SatisYap()
        {
            List<SelectListItem> urun = (from x in _context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();
            List<SelectListItem> cari = (from x in _context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            List<SelectListItem> personel = (from x in _context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SatisYap(SatisHareket satis)
        {
            SatisValidations validation = new SatisValidations();
            ValidationResult result = validation.Validate(satis);
            if (result.IsValid)
            {
                satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                _context.SatisHarekets.Add(satis);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> urun = (from x in _context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();
            List<SelectListItem> cari = (from x in _context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            List<SelectListItem> personel = (from x in _context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;

            return View(satis);
        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {

            var satis = await _context.SatisHarekets.FindAsync(id);

            List<SelectListItem> urun = (from x in _context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();

            List<SelectListItem> cari = (from x in _context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariId.ToString()
                                         }).ToList();

            List<SelectListItem> personel = (from x in _context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();


            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;



            return View(satis);
        }


        [HttpPost]
        public async Task<IActionResult> Güncelle(SatisHareket k)
        {

            SatisValidations validation = new SatisValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var satis = await _context.SatisHarekets.FirstOrDefaultAsync(x => x.SatisId == k.SatisId);
                satis.Urun = k.Urun;
                satis.Cari = k.Cari;
                satis.Personel = k.Personel;
                satis.Adet = k.Adet;
                satis.Fiyat = k.Fiyat;
                satis.ToplamTutar = k.ToplamTutar;
                satis.Tarih = k.Tarih;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(k);







        }


        public async Task<IActionResult> Detay(int id)
        {
            var satisDetay = await _context.SatisHarekets.Include(p => p.Urun).Include(a => a.Cari).Include(c => c.Personel).Where(x => x.SatisId == id).ToListAsync();
            //ViewBag.departman = departmandı;
            //var detay = await _context.Personels.Where(x => x.DepartmanId == id).ToListAsync();
            return View(satisDetay);
        }

    }
}
