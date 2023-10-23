using FonclaraIT_ELEC1C_LabActivity1.Models;
using Microsoft.EntityFrameworkCore;

namespace FonclaraIT_ELEC1C_LabActivity1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }    
        public DbSet<Instructor> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2022-08-26"),
                    GPA = 1.5,
                    Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Zyx",
                    LastName = "Montano",
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2022-08-07"),
                    GPA = 1,
                    Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Aerdriel",
                    LastName = "Montano",
                    Course = Course.BSCS,
                    AdmissionDate = DateTime.Parse("2020-01-25"),
                    GPA = 1.5,
                    Email = "aerdriel@gmail.com"
                }
            );

            modelBuilder.Entity<Instructor>().HasData(
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
                Id = 2,
                FirstName = "Melfred",
                LastName = "Fonclara",
                isTenured = false,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("2023-08-08")
            }
            );
        }

    }
}
