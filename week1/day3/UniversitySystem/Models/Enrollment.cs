using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Enrollment
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public User Student { get; set; }
        public Course Course { get; set; }
    }
}
