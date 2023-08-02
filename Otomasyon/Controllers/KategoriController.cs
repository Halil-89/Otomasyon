using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;
using X.PagedList;

namespace Otomasyon.Controllers
{
    //[Authorize]
    public class KategoriController : Controller
    {
        private readonly Context _context;

        public KategoriController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(int sayfa=1)
        {
            var kategori =  _context.Kategoris.ToList().ToPagedList(sayfa,2);
            return View(kategori);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(Kategori kategori)
        {

            KategoriValidations validation = new KategoriValidations();
            ValidationResult result = validation.Validate(kategori);
            if (result.IsValid)
            {
                _context.Kategoris.Add(kategori);
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

            return View(kategori);


        }


        public async Task<IActionResult> Sil(int id)
        {
            var kategori = await _context.Kategoris.FirstOrDefaultAsync(x => x.KategoriId == id);
            _context.Kategoris.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {
            var kategori = await _context.Kategoris.FindAsync(id);

            return View(kategori);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Kategori k)
        {

            KategoriValidations validation = new KategoriValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var entity = await _context.Kategoris.FirstOrDefaultAsync(x => x.KategoriId == k.KategoriId);
                entity.KategoriAd = k.KategoriAd;
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



    }
}
