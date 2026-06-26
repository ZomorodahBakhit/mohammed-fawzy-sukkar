using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Syllabus
    {
        public int id { get; set; }
        public string description { get; set; } 
        public ICollection<Course> ?Courses { get; set; }
    }
}
