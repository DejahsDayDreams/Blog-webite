using System;
using System.ComponentModel.DataAnnotations;

namespace NCA_FA3.Models
{
    public class Student
    {
        [Key] // Specifies that PostID is the primary key
        public int PostID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Grade is required")]

        public string? Grade { get; set; }

        [Required(ErrorMessage = "Email is required")]

        public string? Email { get; set; }
    }
}


