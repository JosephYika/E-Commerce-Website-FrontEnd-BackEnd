using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Add Controller --> Add View 
// so basically the specified route in the browser will display whatever the action is in the controller
// e.g if we go Appointment/index - this first looks into the action associated with the name Index, looks whats this action does
// in this case in returns the view, so it looks for this specific view and finds it in the Views/Appointments,
// and display the content of that file 
// e.g if we go Appointment Details - this returns the message with an ID
namespace E_Commerce_Website.Controllers
{
    // Attribute based routing on the controller level below: 
   //[Route("Admin/[controller]")]
    public class AppointmentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
            
        }
        
        



        /*Attribute based routing on the action level- defined on the top of the action. 
         * This action will be called when we navigate to URLs such as 
           Blog/Index, Blog/Index/1 
         
        [Route("Blog")]
        [Route("Blog/Index")]
        [Route("Blog/Index/{id?)"]

        public IActionResult Details(int id) // whatever id we pass in the URL on the top in the browser
        {
            return Ok("You have entered id = " + id);
        }
        
        The action above doesn't return any view so it won't look for any. It just returns the message 
       
         */

    }
}
