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


        /*Below we can see some of the actions for the website, they are called once a user navigated
         to the URL matched with the name of the action , e.g Home/Index - of course
         first we have to remember that the routing starts with controller and then action
         Actions are basically methods used to handle the HTTP request , once they are called they return a view 
         or other result , depends what is inside the specific action
        
         1. Any public method inside a controller class is an action
         2. Actions cannot be overloaded in the controller 
         3. Action methods cannot be static
         4. IActionResults is an interface
         5. ActionResult is an abstract class from which different action results inherit
        
         Action parameters: 
        
         Passing parameters to actions is an essential part of building .Net Core Web
         Applications.
        
         There are different was of passing parameters to  action: 
        
         These are basically ways to send informations that a user can later see in the browser
         1. Pass parameter as a part of an URL - where parameters is part of the routing
         2. Pass Parameters with query string. - ([FromQuery] string values) - returns whatever the user has 
         entered in the URL
         3. Pass parameters with headers. ([FromHeader])
         4. Pass parameters with request body. ([FromBody] - we can pass an object for example
         5. Pass Parameters in a form. - allows to upload a file ([FromForm] string filename, [FromForm] IFormfile file)
        

        Action results:  ( so basically the code inside the IAcionResults method)

        Action Results are classes which represent things the client is
        supposed to do as a result of the controller action

        They may need to get a file, or redirect , or do different things. 

        Some action reesults are just there to return a HTTP status code.

        Different types of action results :
        1. Status Code Results - returns results related to the status such as
        Status200Ok Ok(); , Status201 Created(); for example a new item was created , Status204 return NoContent(); Status400 BadRequest(); 
        Status 401 Unauthorized(); , Status404 NotFound(); Status415 return new UnsupportedMediaTypeResults(); 
        So basically returns the results of the user actvitiy in the browser
       
        2. Statu Code with Object Results - similar to Status code, but additionaly we are
        passing an object
        3. Redirect Results - allow for redirection to another page, to specific target on the same page, or to a specific action
  
        4. File Results - allows for returning files e.g. pdf , and there are different ways - physically from wwwroot , or virtually

        5. Content Results - returns the content e.g view, partial view, json - JavaScript Object Notation 
        JSON is a lightweight format for storing and transporting data
        JSON is often used when data is sent from a server to a web page

        

        They basically tell as what types of results the user will get/receive/see in the browser

         */



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
