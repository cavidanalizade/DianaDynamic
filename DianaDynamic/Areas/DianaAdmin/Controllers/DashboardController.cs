using Microsoft.AspNetCore.Mvc;

namespace DianaDynamic.Areas.DianaAdmin.Controllers
{

    [Area("DianaAdmin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
