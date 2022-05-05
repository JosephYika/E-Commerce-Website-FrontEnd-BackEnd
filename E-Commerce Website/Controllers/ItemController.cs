using E_Commerce_Website.Data;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controllers
{
   
    public class ItemController : Controller
    {
        //dependecy injection is used down below 
        //It is a technique where one object receives other object that it depends on
        
        private readonly ApplicationDbContext _db; //object

        public ItemController(ApplicationDbContext db)
        {
            _db = db; // assing the passed object to the first object
        }             // passed object is of type ApplicationDbContext of course
                      
        public IActionResult Index()
        { 
            // retrieve items from the database
            // this will retrieve items from the database and will contain whatever information the database holds e.g. the data inside our tables 
            // this interfacre accepts data type Item, meaning it accepts our Item class that we created before
            // and the Item class has columns for our database
            IEnumerable<Item> objList = _db.Items;
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
        
        public IActionResult Create(Item obj)
        {
            /*Make an entry to the database, save changes and redirect to the Index action*/
            _db.Items.Add(obj); // passing (obj) whatever the user typed into the database
            _db.SaveChanges();
            return RedirectToAction("Index"); // this will display the Index page with the updated table 
        }


        

    }
}
