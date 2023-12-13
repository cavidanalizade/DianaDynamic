using DianaDynamic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DianaDynamic.Controllers
{
    public class HomeController : Controller
    {

        AppDBC _db;
        public HomeController(AppDBC db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm()
            {
                products=_db.products.OrderByDescending(s=>s.Id).Take(5).ToList()
            };
            return View(homeVm);
        }

    }
}