using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;
using System.Security.Claims;


namespace Otomasyon.Controllers
{
    public class LoginController : Controller
    {

        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult PartialCariKAyitView()
        {
            Cari model = new Cari();

            return PartialView("_PartialCariKayitView", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialCariKAyitView(Cari cari)
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

            return PartialView();
        }

        [HttpGet]

        public IActionResult PartialCariGirisView()
        {
            Cari model = new Cari();

            return PartialView("_PartialCariGirisView", model);
        }


        [HttpPost]

        public async Task<IActionResult> PartialCariGirisView(Cari cari)
        {

            var user = await _context.Caris.FirstOrDefaultAsync(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                return RedirectToAction("Index", "Login");


            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.CariMail),
                new Claim("FullName", user.CariAd),
                //new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            HttpContext.Session.SetString("username", cari.CariMail);

            return RedirectToAction("Index", "CariPanel");



        }



        public IActionResult PartialPersonelGirisView()
        {
            Personel model = new Personel();

            return PartialView("_PartialPersonelGirişView", model);
        }

        [HttpPost]

        public IActionResult PartialPersonelGirisView(Admin p)
        {
            var personel = _context.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (personel != null)
            {
                HttpContext.Session.SetString("KullanıcıAd", p.KullaniciAd.ToString());
                return RedirectToAction("Index", "Kategori");
            }

            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
