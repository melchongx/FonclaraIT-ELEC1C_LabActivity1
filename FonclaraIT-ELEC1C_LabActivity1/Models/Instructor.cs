using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FonclaraIT_ELEC1C_LabActivity1.Models
{
    public enum Rank
    {
        instructor, AssistantProfessor, AssociateProfessor, Professor
    }

    public class Instructor
    {
        [Required]  
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Is tenured")]
        public bool isTenured { get; set; }

        [Required]
        [Display(Name = "Academic Rank")]
        public Rank Rank { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; } 

    }
}
