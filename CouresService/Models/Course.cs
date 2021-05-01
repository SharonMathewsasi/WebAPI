using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseService.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public float Fees { get; set; }
        public String Description { get; set; }
        public string Trainer { get; set; }

    }
}