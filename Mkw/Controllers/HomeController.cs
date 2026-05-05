using Microsoft.AspNetCore.Mvc;
using Mkw.Application.ViewModelServices;
using Mkw.Models;
using System.Diagnostics;

namespace Mkw.Controllers
{
    public class HomeController : Controller
    {
        private Home _home;
        public HomeController(Home home)
        {
            _home = home;
        }
        public async Task<IActionResult> Index()
        {
            await _home.Test();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
