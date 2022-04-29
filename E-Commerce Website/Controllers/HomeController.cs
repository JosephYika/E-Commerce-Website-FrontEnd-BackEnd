using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // if we would route to the Home/Index on our website it would call this method
        // down below , so it would call this action
        public IActionResult Index()
        {
            return View(); /* returns the view that has exactly the same name 
                           as the controller  so in this case Home - this is now located under Views/Home in this project
                           Returns what is inside the view based on the name of the file.
                           So in this case Index.cshtml */
                           // try breakpoint - and continue to see how the code jumps from section to section
                   
        }

        public IActionResult Privacy()
        {
            return View();  // and in this case Privacy.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
