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


        /*Post DeletePost. This action is called when the user clicks on Remove button on the Delete Page - MyCourses/Delete.cshtml*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Courses.Find(id); // find id , which is primary key and assign it to variable obj
            if(obj == null) // check object is null
            {
                return NotFound(); // if it is then return not found message
            }

            // if id is not null 
            _db.Courses.Remove(obj);  // remove it , so remove one row
            _db.SaveChanges(); // save changes 
            return RedirectToAction("Index");// redirect to index action
        }


        

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        // Get Update 
        

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Update

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update (MyCourses obj)
        {
            if(ModelState.IsValid)
            {
                _db.Courses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        

    }
}

