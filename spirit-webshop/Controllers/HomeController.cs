using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace spirit_webshop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
 
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
    }
}