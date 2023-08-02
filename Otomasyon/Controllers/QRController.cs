using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace Otomasyon.Controllers
{
   // [Authorize]
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string kod)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator kodurert = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = kodurert.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap resim = karekod.GetGraphic(10)) 
                {
                    resim.Save(ms,ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64,"+Convert.ToBase64String(ms.ToArray());
                }
               
            }

            return View();

        }
    }
}
