using Microsoft.AspNetCore.Mvc;

namespace TagHelpersDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
