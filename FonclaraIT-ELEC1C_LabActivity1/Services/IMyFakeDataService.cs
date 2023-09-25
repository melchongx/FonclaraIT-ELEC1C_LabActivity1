using FonclaraIT_ELEC1C_LabActivity1.Models;
namespace FonclaraIT_ELEC1C_LabActivity1.Services
{
    public interface IMyFakeDataService
    {
        List<Student> StudentList { get; }
        List<Instructor> InstructorList { get; }
    }
}
