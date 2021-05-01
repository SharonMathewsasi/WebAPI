using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseService.Models;

namespace CourseService.Controllers
{
    public class CourseController : ApiController
    {
        static List<Course> courses = new List<Course>()
        {
            new Course(){CourseId=1,CourseName="Android",Trainer="Shawn",Fees=12000,Description="Android is a mobile operating system dev"},
             new Course(){CourseId=2,CourseName="Asp.net",Trainer="rio",Fees=20000,Description="Good performance on riding"}
        };
        public HttpResponseMessage Get([FromUri] string coursename)
        {
            var findedCourse = courses.Where(c => c.CourseName == coursename).SingleOrDefault();
            if (findedCourse == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course Name " + coursename + " not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, findedCourse, "application/json");
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Course course)
        {
            courses.Add(course);
            return Request.CreateResponse(HttpStatusCode.OK, course);
        }
    }
}
