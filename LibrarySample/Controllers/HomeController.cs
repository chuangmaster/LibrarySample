using LibrarySample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibrarySample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //session exist
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewData["Id"] = HttpContext.Session.GetString("Id");
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                //alert error message
                TempData["Message"] = message;
                return RedirectToAction("Index");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Login logic here
                if (loginModel.Id == "admin" && loginModel.Password == "admin")
                {
                    HttpContext.Session.SetString("Id", loginModel.Id);
                    return RedirectToAction("Index");
                }
                else
                {
                    //redrect to error page
                    return RedirectToAction("Error", new { Message = "ID or Password is invalid." });
                }
            }
            return RedirectToAction("Error", new { Message = "ID or Password is invalid." });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
