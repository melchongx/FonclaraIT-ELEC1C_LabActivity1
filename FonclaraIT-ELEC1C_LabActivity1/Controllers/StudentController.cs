using FonclaraIT_ELEC1C_LabActivity1.Data;
using FonclaraIT_ELEC1C_LabActivity1.Models;
using FonclaraIT_ELEC1C_LabActivity1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FonclaraIT_ELEC1C_LabActivity1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View(_dbContext.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

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
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student editStudent)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == editStudent.Id);

            if (student != null)//was an student found?
            {
                student.FirstName = editStudent.FirstName;
                student.LastName = editStudent.LastName;
                student.GPA = editStudent.GPA;
                student.Course = editStudent.Course;
                student.AdmissionDate = editStudent.AdmissionDate;
                student.Email = editStudent.Email;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student deleteStudent)
        { 
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == deleteStudent.Id);

            if (student != null)//was an student found?
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
