using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Migrations;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class UrunController : Controller
    {
        private readonly Context _context;

        public UrunController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string p)
        {

            var Urunler = await _context.Uruns.Include(p => p.Kategori).Where(x => x.Durum == true).ToListAsync();
            if (!string.IsNullOrEmpty(p))
            {
                Urunler=Urunler.Where(x => x.UrunAd.Contains(p)).ToList();
            }
           
            return View(Urunler);
        }


        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            List<SelectListItem> kategori = (from x in _context.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriId.ToString()
                                             }).ToList();
            ViewBag.kategori = kategori;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Urun urun)
        {


            UrunValidations validation = new UrunValidations();
            ValidationResult result = validation.Validate(urun);
            urun.Durum = true;

            if (result.IsValid)
            {
                _context.Uruns.Add(urun);
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

            return View(urun);


        }

        public async Task<IActionResult> Sil(int id)
        {
            var Urun = await _context.Uruns.FirstOrDefaultAsync(x => x.UrunId == id);
            _context.Uruns.Remove(Urun);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {
            var urunkategori = await _context.Uruns.Where(x => x.UrunId == id).Select(x => x.KategoriId).FirstOrDefaultAsync();
            var urun = await _context.Uruns.FindAsync(id);

            List<SelectListItem> kategoriurun = (from x in _context.Kategoris.Where(x => x.KategoriId == urunkategori).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString()
                                                 }).ToList();
            ViewBag.kategoriurun = kategoriurun;



            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Urun k)
        {

            UrunValidations validation = new UrunValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var urun = await _context.Uruns.FirstOrDefaultAsync(x => x.UrunId == k.UrunId);
                urun.UrunAd = k.UrunAd;
                urun.Marka = k.Marka;
                urun.Stok = k.Stok;
                urun.AlisFiyat = k.AlisFiyat;
                urun.SatisFiyat = k.SatisFiyat;
                urun.Durum = k.Durum;
                urun.KategoriId = k.KategoriId;
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

        public async Task<IActionResult> Listele()
        {

            var Urunler = await _context.Uruns.Include(p => p.Kategori).Where(x => x.Durum == true).ToListAsync();
            return View(Urunler);
        }

        [HttpGet]
        public async Task<IActionResult> Satis(int id)
        {

            List<SelectListItem> personel = (from x in _context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();

            var urun = _context.Uruns.Find(id);

           
            ViewBag.personel = personel;
            ViewBag.urun = urun.UrunId;
            //ViewBag.fiyat= Convert.ToInt32(urun.SatisFiyat);
            ViewBag.fiyat = urun.SatisFiyat;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Satis(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            SatisValidations validation = new SatisValidations();
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                _context.SatisHarekets.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Satis");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

           
            return View();
        }


    }
}
