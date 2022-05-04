using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Website.Data;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class MyCoursesController : Controller
    {
        private readonly ApplicationDbContext _db; //object

        public MyCoursesController(ApplicationDbContext db)
        {
            _db = db; // assing the passed object to the first object
        }             // passed object is of type ApplicationDbContext of course

        public IActionResult Index()
        {

            IEnumerable<MyCourses> objList = _db.Courses;
            return View(objList);
            
        }


        // Get create action
        public IActionResult Create()
        {
            return View();
        }


        //Post create action
        //This will be linked with the Create class 
        // Post means basically sending data
        // This method accepts arguments of data type Item, so our class that has table's data i.e columns 
        // So we can send to this IActionResult Create method 

        /*I am also specifiying that this will be https post and validating a token , which 
         basically means that people who are logged in can fill out the form. It will only execute the post request if 
        we are still logged in. So this is only for safety reasons.*/
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(MyCourses obj)
        {
            /*This checks all of the restrictions we added to our data model i.e. to our columns
              e.g the min max range for the price, or the required annotations etc.
             This is called server side validation.*/
           
            if(ModelState.IsValid)
            {
                /*Make an entry to the database, save changes and redirect to the Index action*/
                _db.Courses.Add(obj); // passing (obj) whatever the user typed into the database
                _db.SaveChanges();
                return RedirectToAction("Index"); // this will display the Index page with the updated table 
            }

            return View(obj);
           
        }

    }
}

