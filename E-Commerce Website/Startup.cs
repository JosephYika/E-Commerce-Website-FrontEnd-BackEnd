using E_Commerce_Website.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // DI Container , this is a place where we add our services
        {
            // adding a service that will take care of databas. 
            // In this case I am connecting to the database that was set to be a default connection in json file
            // After adding this service we can install Microsoft.EntityFrameWork.Tools package 
            // Then we can migrite by going to View --> Other Windows --> Package Manager Console 
            // This will open up a console for us to write commands 
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
                
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // checks whether we are in development environment or in production environemtn for example
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())  // If we are in the developent env than ...
            {
                app.UseDeveloperExceptionPage(); // use this 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Middleware: Middleware is software that provides
            // common services and capabilities to applications
            // outside of what's offered by the operating system.
            // Data management, application services, messaging,
            // authentication, and API management are all commonly
            // handled by middleware. MVC is one of the middlewares alongside Auth and HTTPS redirection
            // If there is a request from the browser - the request needs to go first trhough all of the 
            // middlewares e.g - Auth - MVC - HTTPS red - until it reaches the last middleware. Then 
            // the response is returned to the server. 

            /*SO basically : 
             *1. Check if we are in development env 
              2. On the browser request - go trough all of the middle ware*/

            // the request is passed from one middleware to another until the end point, then it returns the response

            // middlewares down below:  
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // wwwroot file is made available by this middleware, this middleware uses the wwwroot files
                                  // in the wwwroot i can add images files for my website  
            app.UseRouting(); 
            /* Routing is the process through which the application matches the requested URL path 
             * and exectues the related Contoller and Action.
             
               There are different ways/ mechanisms to configure routing in any application
               Controllers are one of those ways
            
             
               Routes are defined in the startup code. 
               Routing describes how URL path are matched with the action. 
               Routing is used to generate URLs ( uniform resource locators) for link.
               
               The URL pattern for routing is generated and added to the domain name
               e.g. https: //localhost:1337/controller/action/id
               e.g  https: //localhost:1337/Home/Index  - Controller is Home, Action is Index, Id is Null
                    https: //localhost:1337/Company/Customer/1 
                    https: //localhost:1337/Home - Controller is Home, Action is Index, Id is Null 
                    
               
                    
               */


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // controller and action are set here as default values ,
                // so by default the will alwaus be  Home and Index
                // id here is optional  
                // so if we would enter a website for example https: //localhost:1337 
                // we would still get to Home/Index
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // End points : there are different types of end points e.g MVC , Razor Pages, SignalR
            // in UseRouting method , there will be defined which technology we use e.g MVC etc
        }   // ends point is one end of a communication channel
            // in this case our end point is MVC as defined by the pattern
            // This is called Convention Based Routing - where the route is determined based on 
            // the rules defined in the route templates ( the route template is the template in the Startup.cs - so this file)

        /*We can also have Dedicated conventional routing , which basicaly means that
         we create another endpoint and specificy the pattern dedicated to the controller.


         e.g 

           endpoints.MapControllerRoute{
           name: "blog",
           pattern: "blog/{article}",
           defaults: new {controller = "blog", action = "Article" });

           In the example above we see a convential routing dedicated to controller blog 

          so in this case when we navigate to /Blog, /Blog/Article , /Blog/Article/whatever string 
          this will display the same content of the action method 

          We can also have Attribute Based Routing which means that the routing can be done 
          by setting up attributes at controller level or at action level
          See attribute based routing in the Controllers/AppointmentController.cs
         */





    }
}
