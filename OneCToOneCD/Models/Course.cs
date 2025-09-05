using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCToOneCD.Models
{
    public class Course
    {
        public string CourseShortName { get; set; } = string.Empty;
        [Key]
        [ForeignKey("CourseDetails")]
        public string? CourseCode { get; set; }
        public CourseDetails CourseDetails { get; set; } = null!; //navigation property
    }
}
