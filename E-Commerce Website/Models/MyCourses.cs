using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Models
{
    //New page MyCourses 
    public class MyCourses
    {
        /*Creating Columns for my database */
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Course Name")] // adding annotations 
        public string CourseTitle { get; set; }

        [DisplayName("Course Author")]
        [Required] // required means that a certain action is required , this case
                   // the user input is required 
        public string CourseAuthor { get; set; }

        [Required] // user input is required 
        [Range(1, int.MaxValue, ErrorMessage = "Price cannot be 0 or a negative value.")] // defining a range for the price that the user typed in 
        public int Price { get; set; } 




    }
}
