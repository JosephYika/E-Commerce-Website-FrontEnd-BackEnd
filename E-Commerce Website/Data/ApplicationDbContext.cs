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

        /* Creating Items table */
        public DbSet<Item> Items { get; set; }
    }
}
