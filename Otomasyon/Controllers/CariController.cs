using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;


namespace Otomasyon.Controllers
{
    //[Authorize]
    public class CariController : Controller
    {
        private readonly Context _context;

        public CariController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cariler = await _context.Caris.Where(x => x.Durum == true).ToListAsync();
            return View(cariler);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Cari cari)
        {
            CariValidations validation = new CariValidations();
            ValidationResult result = validation.Validate(cari);
            if (result.IsValid)
            {
                cari.Durum = true;
                _context.Caris.Add(cari);
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

            return View(cari);



        }

        public async Task<IActionResult> Sil(int id)
        {
            var cari = await _context.Caris.FirstOrDefaultAsync(x => x.CariId == id);
            _context.Caris.Remove(cari);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {


            var cari = await _context.Caris.FindAsync(id);

            return View(cari);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Cari k)
        {


            CariValidations validation = new CariValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var entity = await _context.Caris.FirstOrDefaultAsync(x => x.CariId == k.CariId);
                entity.CariAd = k.CariAd;
                entity.CariSoyad = k.CariSoyad;
                entity.CariSehir = k.CariSehir;
                entity.CariMail = k.CariMail;
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


        public async Task<IActionResult> Gecmis(int id)
        {

            var cariadi = await _context.Caris.Where(x => x.CariId == id).Select(a => a.CariAd + " " + a.CariSoyad).FirstOrDefaultAsync();
            ViewBag.cari = cariadi;

            var gecmis = await _context.SatisHarekets.Include(p => p.Personel).Include(a => a.Urun).Where(x => x.CariId == id).ToListAsync();

            return View(gecmis);
        }
    }
}
