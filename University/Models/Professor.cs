using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace University.Models
{
    public class Professor
    {
        [Key]
        public int  Id { get; set; }
        [Required(ErrorMessage = "you must enter the name")]
        public string Name { get; set; }
        [Required]
       
        public int DId {  get; set; }
        [ForeignKey("DId")]
        public Department Department { get; set; }
        
    }
}
