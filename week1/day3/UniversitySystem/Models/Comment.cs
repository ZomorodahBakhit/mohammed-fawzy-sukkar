using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int assignmentId { get; set; }
        public int userId { get; set; }
        public DateTime createdDate { get; set; }
        public string ?content { get; set; }
        public Assignment Assignment { get; set; }
        public User User { get; set; }
    }
}
