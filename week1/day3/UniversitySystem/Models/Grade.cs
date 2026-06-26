using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Grade
    {
        public int id { get; set; }
        public int assignmentId { get; set; }
        public int studentId { get; set; }
        public int? grade { get; set; }
        public Assignment Assignment { get; set; }
        public User Student { get; set; }
    }
}
