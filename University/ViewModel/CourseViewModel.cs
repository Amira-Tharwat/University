using University.Models;

namespace University.ViewModel
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Professor> professors { get; set; }
    }
}
