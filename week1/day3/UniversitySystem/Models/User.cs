using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string role { get; set; }
        public ICollection<Comment> ?Comments { get; set; }
        public ICollection<Grade> ?Grades { get; set; }
        public ICollection<Course> ?Courses { get; set; }
        public ICollection<Enrollment> ?Enrollments { get; set; }

    }
}
