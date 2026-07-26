using Microsoft.AspNetCore.Mvc;

namespace Yaqeen.API.Controllers
{
    public class CitizenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
