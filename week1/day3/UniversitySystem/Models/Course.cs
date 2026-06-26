using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ?teacherId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int ?syllabusId { get; set; }
        public User ?teacher { get; set; }
        public Syllabus ?Syllabus { get; set; }
        public ICollection<Assignment> ?Assignments {get; set;}
        public ICollection<Enrollment> ?Enrollments { get; set;}
    }
}
