namespace FonclaraIT_ELEC1C_LabActivity1.Models
{
    public enum Rank
    {
        instructor, AssistantProfessor, AssociateProfessor, Professor
    }

    public class Instructor
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isTenured { get; set; }
        public Rank Rank { get; set; }
        public DateTime HiringDate { get; set; } 

    }
}
