using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_Website.Data;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class MyBasketController : Controller
    {
        private readonly ApplicationDbContext _db; //object

        public MyBasketController(ApplicationDbContext db)
        {
            _db = db; // assing the passed object to the first object
        }             // passed object is of type ApplicationDbContext of course

        public IActionResult Index()
        {
            
            return View();
        }
       
    }
}
