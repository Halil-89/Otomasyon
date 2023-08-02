using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Otomasyon.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();


            if (statusCodePagesFeature is not null)
            {
                statusCodePagesFeature.Enabled = false;
            }

           

            return View();
        }

        public IActionResult Page400()
        {
            Response.StatusCode = 400;

            return View("PageError");
        }
    }
}
