using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class MesajController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
