using Microsoft.AspNetCore.Mvc;
using MVCDemo1.Models;
using MVCDemo1.Utility;

namespace MVCDemo1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            Student student1 = new Student()
            {
                Id = 1,
                Name = "Student1",
                Age = 21
            }; Student student2 = new Student()
            {
                Id = 2,
                Name = "Student2",
                Age = 21
            }; Student student3 = new Student()
            {
                Id = 3,
                Name = "Student3",
                Age = 21
            };

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            return students;
        }

        public List<Courses> GetCourses()
        {
            List<Courses> courses = new List<Courses>();

            courses.Add(new Courses()
            {
                CourseId = 1,
                CourseName = "Course1",
            });
            courses.Add(new Courses()
            {
                CourseId = 2,
                CourseName = "Course2"

            });

            courses.Add(new Courses()
            {
                CourseId = 3,
                CourseName = "Course3"
            });

            return courses;

        }
        public ViewResult ShowStudents()
        {
            List<Student> students = GetStudents();
            ViewBag.Students = students;
            ViewBag.Title = "Students List";
            return View();
        }

        public ViewResult DisplayStudents()
        {
            List<Student> students = GetStudents();
            return View(students);
        }

        public ViewResult DisplayStudentsAndCourses()
        {
            List<Student> students = GetStudents();
            List<Courses> courses = GetCourses();

            Combined combined = new Combined();
            combined.students = students;
            combined.courses = courses;

            return View(combined);

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
