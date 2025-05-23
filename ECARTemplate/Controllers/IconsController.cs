using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]
    public class IconsController : Controller
    {
        public IActionResult FontawesomeBrand() => View();
        public IActionResult FontawesomeDuotone() => View();
        public IActionResult FontawesomeLight() => View();
        public IActionResult FontawesomeRegular() => View();
        public IActionResult FontawesomeSolid() => View();
        public IActionResult NextgenBase() => View();
        public IActionResult NextgenGeneral() => View();
        public IActionResult StackGenerate() => View();
        public IActionResult StackShowcase() => View();
        public IActionResult WebfontsFaq() => View();
    }
}
