using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniWebApp.Models
{
    public class Course
    {
        [Key]
        public int CrsId { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        public string CrsCode { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CrsName { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }

        [Required]
        public string year { get; set; }

        public string Grade { get; set; }

        public double GradePoint
        {
            get
            {
                switch (Grade?.ToUpper())
                {
                    case "A+": return 4.0;
                    case "A": return 3.7;
                    case "B+": return 3.3;
                    case "B": return 3.0;
                    case "C+": return 2.7;
                    case "C": return 2.4;
                    case "D+": return 2.2;
                    case "D": return 2.0;
                    case "F": return 0.0;
                    default: return 0.0;
                }
            }
        }

        public double TermWork { get; set; }

        public double ExamWork { get; set; }

        public double Result => TermWork + ExamWork;

        [Required]
        public string Level { get; set; } 

        [Required]
        [Display(Name = "Term")]
        public string Semester { get; set; }

        [Required]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }


       // public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


        public ICollection<Course>? Prerequisites { get; set; } = new List<Course>();


        public ICollection<Course>? RequiredBy { get; set; } = new List<Course>();


    }
}
