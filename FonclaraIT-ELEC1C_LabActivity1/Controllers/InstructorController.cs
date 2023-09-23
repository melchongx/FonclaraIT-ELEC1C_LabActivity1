using FonclaraIT_ELEC1C_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace FonclaraIT_ELEC1C_LabActivity1.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Melfred",
                LastName = "Fonclara",
                isTenured = false,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("2023-08-08")
            },
            new Instructor()
            {
                Id = 1,
                FirstName = "Melfred",
                LastName = "Fonclara",
                isTenured = false,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("2023-08-08")
            }
        };
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(ins => ins.Id == id);
            
            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor editInstructor)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(ins => ins.Id == editInstructor.Id);

            if (instructor != null)
            {
                instructor.FirstName = editInstructor.FirstName;
                instructor.LastName = editInstructor.LastName;
                instructor.isTenured = editInstructor.isTenured;
                instructor.Rank = editInstructor.Rank;
                instructor.HiringDate = editInstructor.HiringDate;
                return View("Index", InstructorList);
            }

            return NotFound();
        }

        public IActionResult DeleteStudent(Instructor instructor)
        {
            InstructorList.RemoveAt(instructor.Id-1);
            return View("Index", InstructorList);
        }
    }
}
