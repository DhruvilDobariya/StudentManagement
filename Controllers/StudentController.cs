using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _db;

        //here we create a constructor, so we inject dependency
        public StudentController(StudentDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable < Student > students = _db.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            //here we put server side validation
            if (ModelState.IsValid)
            {
                _db.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound("Page Not Found");
            }
            var student = _db.Students.Find(id);
            if(student == null)
            {
                return NotFound("Page Not Found");
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound("Page Not Found");
            }
            var student = _db.Students.Find(id);
            if(student == null)
            {
                return NotFound("Page Not Found");
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student student)
        {
            if(student.StudentID == null && student.StudentID == 0)
            {
                return NotFound("Page Not Found");
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
