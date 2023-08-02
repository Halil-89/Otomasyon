using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class CariPanelController : Controller
    {
        private readonly Context _context;

        public CariPanelController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var test = HttpContext.Session.GetString("username");

            var user = _context.Caris.Where(x => x.CariMail == test).ToList();

            var userId = user.Select(x => x.CariId).FirstOrDefault();

            var toplamsatis = _context.SatisHarekets.Where(x => x.CariId == userId).Count();

            var toplamtutar = _context.SatisHarekets.Where(x => x.CariId == userId).Sum(x => x.ToplamTutar);
            var toplamurun = _context.SatisHarekets.Where(x => x.CariId == userId).Sum(x => x.Adet);



            ViewBag.userid = userId;
            ViewBag.toplamsatis = toplamsatis;
            ViewBag.toplamtutar = toplamtutar;
            ViewBag.toplamurun = toplamurun;

            return View(user);
        }

        public IActionResult Siparislerim()
        {
            var mail = HttpContext.Session.GetString("username");

            var userId = _context.Caris.Where(x => x.CariMail == mail.ToString()).Select(x => x.CariId).FirstOrDefault();
        
            var siparisler = _context.SatisHarekets.Include(p => p.Urun).Where(x => x.CariId == userId).ToList();

            return View(siparisler);
        }

        public IActionResult GelenMesaj()
        {
            var mail = HttpContext.Session.GetString("username");
            var mesajlar = _context.Mesajs.Where(x=>x.Alici==mail).OrderByDescending(x=>x.MesajId).ToList();
            var mesajsayisi = mesajlar.Count();
            ViewBag.mesajsayisi = mesajsayisi;

            return View(mesajlar);
        }

        public IActionResult GidenMesaj()
        {
            var mail = HttpContext.Session.GetString("username");
            var mesajlar = _context.Mesajs.Where(x => x.Gönderici == mail).OrderByDescending(x => x.MesajId).ToList();
            var mesajsayisi = mesajlar.Count();
            ViewBag.mesajsayisigiden = mesajsayisi;

            return View(mesajlar);
        }

        public IActionResult MesajDetay(int id)
        {
            var detay = _context.Mesajs.Where(x => x.MesajId == id).ToList();
            var mail = HttpContext.Session.GetString("username");

            var mesajlargelen = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            var mesajlargiden = _context.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.mesajsayisi = mesajlargelen;
            ViewBag.mesajsayisigiden = mesajlargiden;

            return View(detay);
        }

        public IActionResult YeniMesaj()
        {
           
            var mail = HttpContext.Session.GetString("username");

            var mesajlargelen = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            var mesajlargiden = _context.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.mesajsayisi = mesajlargelen;
            ViewBag.mesajsayisigiden = mesajlargiden;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniMesaj(Mesaj m)
        {

            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mail = HttpContext.Session.GetString("username");
            m.Gönderici = mail;

            MesajValidations validation = new MesajValidations();
            ValidationResult result = validation.Validate(m);
            
            if (result.IsValid)
            {
                _context.Mesajs.Add(m);
                await _context.SaveChangesAsync();
                return RedirectToAction("GidenMesaj");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(m);

        }

        public async Task<IActionResult> KargoTakip( string p)
        {
            var kargolar = await _context.KargoDetays.ToListAsync();
            kargolar = kargolar.Where(x => x.TakipKodu.Contains(p)).ToList();
            return View(kargolar);
           
        }

        public async Task<IActionResult> KargoDetay(string id)
        {
            var kargoTakip = await _context.KargoTakips.Where(x => x.TakipKodu == id).ToListAsync();

            return View(kargoTakip);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
