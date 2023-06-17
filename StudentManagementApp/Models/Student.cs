using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string? FatherName { get; set; }
    }
}
