using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetOpenX50;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.Models.ModelViews;
using Otomasyon.ValidationRules;
using Fatura = Otomasyon.Models.Entities.Fatura;

namespace Otomasyon.Controllers
{
    //    [Authorize]
    public class FaturaController : Controller
    {

        private readonly Context _context;

        public FaturaController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var faturalar = await _context.Faturas.ToListAsync();
            return View(faturalar);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Fatura fatura)
        {
            FaturaValidations validation = new FaturaValidations();
            ValidationResult result = validation.Validate(fatura);
            if (result.IsValid)
            {
                _context.Faturas.Add(fatura);
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

            return View(fatura);
        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {
            var Fatura = await _context.Faturas.FindAsync(id);

            return View(Fatura);
        }


        [HttpPost]
        public async Task<IActionResult> Güncelle(Fatura k)
        {

            FaturaValidations validation = new FaturaValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var fatura = await _context.Faturas.FirstOrDefaultAsync(x => x.FaturaId == k.FaturaId);
                fatura.FaturaSeriNo = k.FaturaSeriNo;
                fatura.FaturaSıraNo = k.FaturaSıraNo;
                fatura.Tarih = k.Tarih;
                fatura.VergiDairesi = k.VergiDairesi;
                fatura.Saat = k.Saat;
                fatura.TeslimAlan = k.TeslimAlan;
                fatura.TeslimEden = k.TeslimEden;

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
            var faturakalem = await _context.FaturaKalems.Where(x => x.FaturaId == id).ToListAsync();

            return View(faturakalem);
        }
        [HttpGet]
        public async Task<IActionResult> Yeni()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Yeni(FaturaKalem kalem)
        {

            FaturaKalemValidations validation = new FaturaKalemValidations();
            ValidationResult result = validation.Validate(kalem);
            if (result.IsValid)
            {
                _context.FaturaKalems.Add(kalem);
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

            return View(kalem);
        }

        public async Task<IActionResult> Dinamik()
        {
            FaturaKalemViewModel model = new FaturaKalemViewModel();
            model.Fatura = _context.Faturas.Include(x => x.FaturaKalems).ToList();
            return View(model);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {

            var fatura = new Fatura()
            {
                FaturaSeriNo = FaturaSeriNo,
                FaturaSıraNo = FaturaSıraNo,
                Tarih = Tarih,
                VergiDairesi = VergiDairesi,
                Saat = Saat,
                TeslimAlan = TeslimAlan,
                TeslimEden = TeslimEden,
                Toplam = decimal.Parse(Toplam)
            };


            foreach (var x in kalemler)
            {
                var faturaKalem = new FaturaKalem()
                {
                    Aciklama = x.Aciklama,
                    BirimFiyat = x.BirimFiyat,
                    Miktar = x.Miktar,
                    Tutar = x.Tutar,
                    Fatura=fatura
                };
                _context.Add(faturaKalem);
            }

           
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}

