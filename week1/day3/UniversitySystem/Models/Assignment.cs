using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Assignment
    {
        public int id { get; set; }
        public int courseId { get; set; }
        public string title { get; set; }
        public string ?description { get; set; }
        public float weight { get; set; }
        public int maxGrade { get; set; }
        public DateTime dueDate { get; set; }
        public Course Course { get; set; }
        public ICollection<Comment> ?Comments { get; set; }
    }
}
