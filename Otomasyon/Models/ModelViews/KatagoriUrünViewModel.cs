using Microsoft.AspNetCore.Mvc.Rendering;

namespace Otomasyon.Models.ModelViews
{
    public class KatagoriUrünViewModel
    {
        public IEnumerable<SelectListItem> Katagoriler { get; set; }
        public IEnumerable<SelectListItem> Urunler { get; set; }
    }
}
