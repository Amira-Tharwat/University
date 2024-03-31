using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private static List<Professor> _professors=new List<Professor>();
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
            _professors.Add(new Professor { Id=1 , Name="ali" , DId=1 });
            _professors.Add(new Professor { Id=2 , Name= "amira", DId= 2 });


        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var prof =_db.Professors.ToList();
            var CourseView = new CourseViewModel()
            {
                professors = prof
            };
            return View(CourseView);
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            var prof = _db.Professors.ToList();
            var CourseView = new CourseViewModel()
            {
                professors = prof
            };
           
            _db.Courses.Add(course);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult View()
        {
            var Course =_db.Courses.Include(m=>m.Professor).ToList();
            return View(Course);
        }
        public IActionResult Update(int id)
        {
            var prof = _db.Professors.ToList();
            var CourseView = new CourseViewModel()
            {
                professors = prof
            };
            CourseView.Course = _db.Courses.FirstOrDefault(m => m.Id == id);
            return View(CourseView);
        }
        [HttpPost]
        public IActionResult Update(Course course)
        {
            Course NewCourse=_db.Courses.FirstOrDefault(m=>m.Id==course.Id);
            NewCourse.Name= course.Name;
            NewCourse.PID= course.PID;
            _db.Courses.Update(NewCourse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id )
        { 
            Course? course = _db.Courses.FirstOrDefault(m => m.Id == id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("view");
        }
    }
}
