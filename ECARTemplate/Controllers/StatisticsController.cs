using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]
    public class StatisticsController : Controller
    {
        public IActionResult C3() => View();
        public IActionResult Chartist() => View();
        public IActionResult Chartjs() => View();
        public IActionResult Dygraph() => View();
        public IActionResult Easypiechart() => View();
        public IActionResult Flot() => View();
        public IActionResult Peity() => View();
        public IActionResult Sparkline() => View();
    }
}
