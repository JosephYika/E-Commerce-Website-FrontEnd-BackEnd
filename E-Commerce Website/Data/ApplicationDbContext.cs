using E_Commerce_Website.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Data
{
    /* ApplicationDbContext inherits from DbContext which is
     * in Microsoft.EntityFramweorkCore.DbContext*/
    public class ApplicationDbContext :DbContext 
    {
        /* ctor + tab creates constructor 
         Here I am setting the database context */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        /* Creating Items table. Here We are using Abstrac class DbSet which is available to us 
         * from the EF Core , click : Ctr + mouse click on DbSet to see where it was originally created, 
         this was of course not created by me , but automatically installed after installing the EF Core */
        public DbSet<Item> Items { get; set; }

        // creating courses table
        public DbSet<MyCourses> Courses { get; set; }
        public IEnumerable<MyCourses> MyCourses { get; internal set; }
    }
}
