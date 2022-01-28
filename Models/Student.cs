using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [Range(1,8,ErrorMessage = "Please enter valid semester")]
        public int Semester { get; set; }
        public string Class { get; set; }
    }
}
