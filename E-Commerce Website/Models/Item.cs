using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // add data annotations to specifiy keys
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Models
{
    public class Item
    {
         
         /* Setting the primary key. In here I defined my columns. I am also using a Code First approach
          . This means that I am creating my columns here by coding, rather than in the database.
          Using this approach I can start writing my entities here and then createa a database using migration commands.
          
          So the workflow in here is: 
         
          Create/Modify domain classes --> Configure domain classes --> Automated/code-based migration --> Database
         
          Migration is a way of keeping the database in synchronization with the model so with our code 
          and with our Entitiy Framework Core . 
          When developing applications the model is most likely to change from time to time as there will be for example
          new requirements for the data that needs to be stored . Migration feature enebles us to make changes to the model and propagate those changes
          to the database schema. Migrations are enabled by default in EF Core.
          EF Core migration are a set of commands which we can execute in NuGet Package Manager Console or in the 
          dotnet CLI.

          The workflow of EF Core migration: 

          PCM : 
          add-migration "name of the migration"  - creates a migration by adding a migration snapshot
          Remove-migration  - removes the last migration snapshot. 
          Update-database- updates the database schema based on the last migration snapshot
          Script-migration - generates SQL script using all the migration snapshots. 

          dotnet CLI:
          Add "migration name" 
          Remove
          Update
          Script 

          If I want to create a table using the model down below i need to set the connection strings in the SQl server management studio.
          We can connect to the server in the appsettings.json file

          So the Work flow is : 
          First ensure we have got all of the Nugget packages installed EntityFrameWorkCore + EFSqlServer + EFTools, 
          Create columns in the new c# class under Models folders --> define connection string in the json file --> 
          --> set up a DbContext in the c# file ( this can be done in a new folder called "Data") --> in the startup file add  a service that takes care of the connection with the database 
          --> lunch Package Manager Console and run migration commands
          */
         [Key] 
         public int Id { get; set; }

         public string Borrower { get; set; }
    }
}
