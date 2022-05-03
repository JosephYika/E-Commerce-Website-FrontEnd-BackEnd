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
        //dependecy injection:  is a technique where one object receives other object that it depends on
        
        private readonly ApplicationDbContext _db; //object

        public ItemController(ApplicationDbContext db)
        {
            _db = db; // assing the passed object to the first object
        }             // passed object is of type ApplicationDbContext of course
                      
        public IActionResult Index()
        {
            // retrieve items from the database
            // this will retrieve items from the database and will contain whatever information the database holds e.g. the data inside our tables 
            IEnumerable<Item> objList = _db.Items;
            return View(objList); 
        }
    }
}
