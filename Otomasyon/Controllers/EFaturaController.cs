using Microsoft.AspNetCore.Mvc;
using NetOpenX50;
using System.Runtime.InteropServices;

namespace Otomasyon.Controllers
{
    public class EFaturaController : Controller
    {
        public IActionResult Index()
        {

            Kernel kernel = new Kernel();
            Sirket sirket = default(Sirket);
            EBelge eBelge = default(EBelge);

            try
            {
                sirket = kernel.yeniSirket(TVTTipi.vtMSSQL,
                 "EKOLGRUP",
                 "TEMELSET",
                 "",
                 "halil.degirmentepe",
                 "Master.890",
                 400);

                eBelge = kernel.yeniEBelge(sirket, TEBelgeTip.ebtEIrs);
                eBelge.EBelgeGoruntuleme("JA32023000001243", @"C:\temp", TEBelgeBoxType.ebOutbox, "");
            }
            finally
            {
                Marshal.ReleaseComObject(eBelge);
                sirket.LogOff();
                Marshal.ReleaseComObject(sirket);
                kernel.FreeNetsisLibrary();
                Marshal.ReleaseComObject(kernel);
            }
           
            return View("Index");

        }
       
    }
}
