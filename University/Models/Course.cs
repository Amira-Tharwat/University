using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the name")]
        public string Name { get; set; }
        [Required]
        public int PID { get; set; }
        [ForeignKey("PID")]
        public Professor Professor { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
