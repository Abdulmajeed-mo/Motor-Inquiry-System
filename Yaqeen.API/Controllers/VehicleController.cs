using Microsoft.AspNetCore.Mvc;

namespace Yaqeen.API.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
