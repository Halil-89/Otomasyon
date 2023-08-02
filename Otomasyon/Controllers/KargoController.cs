using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class KargoController : Controller
    {

        private readonly Context _context;

        public KargoController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string p)
        {
            var kargolar = await _context.KargoDetays.ToListAsync();
            
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(x => x.TakipKodu.Contains(p)).ToList();
            }
            return View(kargolar);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D" };

            int k1, k2, k3;
            k1 = random.Next(0,4); //10 karakter=> 3 1 2 1 2 1 
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);

            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);

            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takip=kod;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(KargoDetay kargo)
        {

            KargoDetayValidations validation = new KargoDetayValidations();
            ValidationResult result = validation.Validate(kargo);
            
            if (result.IsValid)
            {
                _context.KargoDetays.Add(kargo);
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

            return View(kargo);


        }

        public async Task<IActionResult> Detay(string id)
        {
            var kargoTakip = await _context.KargoTakips.Where(x => x.TakipKodu == id).ToListAsync();
          
            return View(kargoTakip);
        }

    }
}
