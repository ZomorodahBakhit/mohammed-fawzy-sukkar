using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystemApi.Core.Forms
{
    public class CreateCourseForm
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Range(0,100, ErrorMessage = "course weight range is between 0 and 100")]
        public int Weight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
