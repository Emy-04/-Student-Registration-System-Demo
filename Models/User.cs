using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniWebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "University ID")]
        public string UniversityId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Range(0.0, 4.0)]
        public double GPA { get; set; }

       

        [Required]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        public  Department? Department { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        

        [Phone]
        [RegularExpression(@"\d{11}", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }



        public string? Address { get; set; }

        [Required]
        [Display(Name = "Entry Year")] 
        public int? EntryYear { get; set; }
        [Display(Name = "First Language")]
        public string? FirstLanguage { get; set; }

        [Display(Name = "Second Language")]
        public string? SecondLanguage { get; set; }


        //public ICollection<Enrollment>? Enrollments { get; set; }

        // public double TotalGrades => Enrollments?.Sum(e => e.Result) ?? 0;
    }
}
