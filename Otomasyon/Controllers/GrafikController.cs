using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Otomasyon.Controllers
{
   // [Authorize]
    public class GrafikController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
