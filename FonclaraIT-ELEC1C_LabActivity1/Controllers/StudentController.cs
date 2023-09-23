using FonclaraIT_ELEC1C_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FonclaraIT_ELEC1C_LabActivity1.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
            {
                new Student()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2022-08-26"), GPA = 1.5, Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", Course = Course.BSIS, AdmissionDate = DateTime.Parse("2022-08-07"), GPA = 1, Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2020-01-25"), GPA = 1.5, Email = "aerdriel@gmail.com"
                }
            };
        public IActionResult Index()
        {

            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student editStudent)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == editStudent.Id);

            if (student != null)//was an student found?
            {
                student.FirstName = editStudent.FirstName;
                student.LastName = editStudent.LastName;
                student.GPA = editStudent.GPA;
                student.Course = editStudent.Course;
                student.AdmissionDate = editStudent.AdmissionDate;
                student.Email = editStudent.Email;
                return View("Index", StudentList);

            }

            return NotFound();
        }

        public IActionResult DeleteStudent(Student student)
        {
            StudentList.RemoveAt(student.Id-1);
            return View("Index", StudentList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
