using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;
using Otomasyon.Models.Entities;
using Otomasyon.ValidationRules;
using System.Net.Http.Headers;

namespace Otomasyon.Controllers
{
  //  [Authorize]
    public class PersonelController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _environment;

        public PersonelController(Context context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var personel = await _context.Personels.Include(p => p.Departman).ToListAsync();
            return View(personel);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            List<SelectListItem> departman = (from x in _context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DeparmanAd,
                                                  Value = x.DepartmanId.ToString()
                                              }).ToList();
            ViewBag.departman = departman;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(Personel personel)
        {


            PersonelValidations validation = new PersonelValidations();
            ValidationResult result = validation.Validate(personel);
            if (result.IsValid)
            {

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_environment.WebRootPath, @"images\personel");
                    var ext = Path.GetExtension(files[0].FileName);
                    if (personel.PersonelGorsel != null)
                    {
                        var imagePath = Path.Combine(_environment.WebRootPath, personel.PersonelGorsel.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    personel.PersonelGorsel = @"\images\personel\" + fileName + ext;
                }

                _context.Personels.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(personel);



        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(int id)
        {
            var departmanId = await _context.Personels.Where(x => x.PersonelId == id).Select(x => x.DepartmanId).FirstOrDefaultAsync();
            var personel = await _context.Personels.FindAsync(id);

            List<SelectListItem> departman = (from x in _context.Departmans.Where(x => x.DepartmanId == departmanId).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DeparmanAd,
                                                  Value = x.DepartmanId.ToString()
                                              }).ToList();
            ViewBag.departman = departman;



            return View(personel);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Personel k)
        {

            PersonelValidations validation = new PersonelValidations();
            ValidationResult result = validation.Validate(k);
            if (result.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_environment.WebRootPath, @"images\personel");
                    var ext = Path.GetExtension(files[0].FileName);
                    if (k.PersonelGorsel != null)
                    {
                        var imagePath = Path.Combine(_environment.WebRootPath, k.PersonelGorsel.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    k.PersonelGorsel = @"\images\personel\" + fileName + ext;
                }

                var personel = await _context.Personels.FirstOrDefaultAsync(x => x.PersonelId == k.PersonelId);
                personel.PersonelAd = k.PersonelAd;
                personel.PersonelSoyad = k.PersonelSoyad;
                personel.PersonelGorsel = k.PersonelGorsel;
                personel.DepartmanId = k.DepartmanId;

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

        public async Task<IActionResult> Liste()
        {

            var personel = await _context.Personels.Include(p => p.Departman).ToListAsync();
            return View(personel);
        }

    }
}
