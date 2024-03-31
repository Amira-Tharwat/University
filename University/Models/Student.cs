using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="you must enter the first name")]
        public string FName { get; set; }
        [Required(ErrorMessage = "you must enter the last name")]
        public string LName { get; set; }
        [Required(ErrorMessage = "you must enter the your email")]
        [EmailAddress]
        public string Email { get; set; }
        public string Major { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
