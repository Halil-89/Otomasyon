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
    public class DepartmanController : Controller
    {
        private readonly Context _context;

        public DepartmanController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departman = await _context.Departmans.Where(x => x.Durum == true).ToListAsync();

            return View(departman);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(Departman departman)
        {

            DepartmanValidations validation = new DepartmanValidations();
            ValidationResult result = validation.Validate(departman);
            departman.Durum = true;
            if (result.IsValid)
            {
                _context.Departmans.Add(departman);
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

            return View(departman);


        }

        public async Task<IActionResult> Sil(int id)
        {
            var departman = await _context.Departmans.FirstOrDefaultAsync(x => x.DepartmanId == id);
            _context.Departmans.Remove(departman);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {
            var departman = await _context.Departmans.FindAsync(id);

            return View(departman);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Departman k)
        {

            DepartmanValidations validation = new DepartmanValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var entity = await _context.Departmans.FirstOrDefaultAsync(x => x.DepartmanId == k.DepartmanId);
                entity.DeparmanAd = k.DeparmanAd;
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
            var departmandı = await _context.Departmans.Where(x => x.DepartmanId == id).Select(x => x.DeparmanAd).FirstOrDefaultAsync();
            ViewBag.departman = departmandı;
            var detay = await _context.Personels.Where(x => x.DepartmanId == id).ToListAsync();
            return View(detay);
        }

        public async Task<IActionResult> PersonelSatıs(int id)
        {
            var satis = await _context.SatisHarekets.Include(x => x.Cari).Include(x => x.Urun).Where(x => x.PersonelId == id).ToListAsync();

            var personel = await _context.Personels.Where(x => x.PersonelId == id).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefaultAsync();
            ViewBag.personel = personel;

            return View(satis);
        }


    }
}
