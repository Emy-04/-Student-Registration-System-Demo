using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniWebApp.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
