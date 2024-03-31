using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the name")]
        public string Name { get; set; }
       

    }
}
