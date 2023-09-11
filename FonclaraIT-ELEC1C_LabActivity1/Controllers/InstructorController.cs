using FonclaraIT_ELEC1C_LabActivity1.Models;
using Microsoft.AspNetCore.Mvc;

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
                HiringDate = DateOnly.Parse("2023-08-08")
            },
            new Instructor()
            {
                Id = 1,
                FirstName = "Melfred",
                LastName = "Fonclara",
                isTenured = false,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateOnly.Parse("2023-08-08")
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
    }
}
