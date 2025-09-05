using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneCToOneCD.Models
{
    public class CourseDetails
    {
        [Key]
        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set;} = string.Empty;
        [Column(TypeName="decimal(6,2)")] //maximum value is 9999.99
        public decimal Price { get; set; }  
        public int DurationInWeeks { get; set; }
        public Course Course { get; set; } = null!; //navigation property - link to other table
    }
}
