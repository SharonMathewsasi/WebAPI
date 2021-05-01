using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        LearnTodayWebAPIDbEntities1 db = new LearnTodayWebAPIDbEntities1();
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses.ToList();

        }
        public HttpResponseMessage GetCourseById(int id)
        {
            var course = db.Courses.Where(c => c.CourseId == id).SingleOrDefault();
            if (course == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, course);
            }

        }
    }
}
