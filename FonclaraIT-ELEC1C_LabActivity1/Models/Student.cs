using System.ComponentModel.DataAnnotations;

namespace FonclaraIT_ELEC1C_LabActivity1.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS, OTHER
    }

    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("[1.00-5.00]")]
        public double GPA { get; set; }

        [Required]
        public Course Course { get; set; }

        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
