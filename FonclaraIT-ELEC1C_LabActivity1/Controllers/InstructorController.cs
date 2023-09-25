using FonclaraIT_ELEC1C_LabActivity1.Models;
using FonclaraIT_ELEC1C_LabActivity1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace FonclaraIT_ELEC1C_LabActivity1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == id);
            
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
            _fakeData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor editInstructor)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == editInstructor.Id);

            if (instructor != null)
            {
                instructor.FirstName = editInstructor.FirstName;
                instructor.LastName = editInstructor.LastName;
                instructor.isTenured = editInstructor.isTenured;
                instructor.Rank = editInstructor.Rank;
                instructor.HiringDate = editInstructor.HiringDate;
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(Instructor deleteInstructor)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(ins => ins.Id == deleteInstructor.Id);

            if (instructor != null)
            {
                _fakeData.InstructorList.Remove(instructor);
            }
            return RedirectToAction("Index");
        }
    }
}
