using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using University.Data;
using University.Models;
using University.ViewModel;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private static List<Course> _courses= new List<Course>();
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
              _db = db;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var course = _db.Courses.ToList();
            var StudentView = new StudentViewModel()
            {
                Courses = course
            };
            return View(StudentView);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult View()
        {
            var Student =_db.Students.ToList();
            return View(Student);
        }
        public IActionResult Update(int id)
        {
            var course = _db.Courses.ToList();
            var StudentView = new StudentViewModel()
            {
                Courses = course
            };
            StudentView.Student = _db.Students.FirstOrDefault(m => m.Id == id);
            return View(StudentView);
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            Student news = _db.Students.FirstOrDefault(m => m.Id == std.Id);
            news.FName = std.FName;
            news.LName = std.LName;
            news.Email = std.Email;
            news.Email= std.Email;
            _db.Students.Update(news);
            _db.SaveChanges();
            return RedirectToAction();
        }



        public IActionResult Delete(int id)
        {
            Student? student = _db.Students.FirstOrDefault(m => m.Id == id);
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("View");
        }
        public IActionResult AssignCourse(int id)
        {
            var course = _db.Courses.ToList();
            var StudentView = new StudentViewModel()
            {
                Courses = course
            };
            StudentView.Student = _db.Students.FirstOrDefault(m => m.Id == id);
            return View(StudentView);
        }
        [HttpPost]
        public IActionResult AssignCourse(Student student)
        {
            
            return RedirectToAction("index");
        }

    }
}
