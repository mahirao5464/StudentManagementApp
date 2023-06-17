using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.Models;

namespace StudentManagementApp.Controllers
{
    public class StudentsController : Controller
    {
        private static readonly List<Student> _students = new List<Student>
            {
                new Student { Id = 1, Name = "John", FatherName = "Smith" },
                new Student { Id = 2, Name = "Jane", FatherName = "Doe" },
                new Student { Id = 3, Name = "Mike", FatherName = "Johnson" },
                new Student { Id = 4, Name = "Sarah", FatherName = "Williams" },
                new Student { Id = 5, Name = "David", FatherName = "Brown" },
                new Student { Id = 6, Name = "Emily", FatherName = "Miller" },
                new Student { Id = 7, Name = "Daniel", FatherName = "Anderson" },
                new Student { Id = 8, Name = "Olivia", FatherName = "Taylor" },
                new Student { Id = 9, Name = "Andrew", FatherName = "Wilson" },
                new Student { Id = 10, Name = "Sophia", FatherName = "Davis" }
            };

        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(elm=>elm.Id == id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var maxId = _students.Max(el => el.Id);
            student.Id = ++maxId;
            _students.Add(student);

            return Redirect(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(elm => elm.Id == id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var student = _students.FirstOrDefault(elm => elm.Id == id);

            if (student is null)
            {
                return NotFound();
            }

            _students.Remove(student);

            return Redirect(nameof(Index));
        }
    }
}
