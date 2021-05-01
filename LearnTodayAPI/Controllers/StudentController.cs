using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        LearnTodayWebAPIDbEntities1 db = new LearnTodayWebAPIDbEntities1();

        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses.ToList();

        }
        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody] Student model)
        {

            try
            {
                db.Students.Add(model);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }

        }
        [HttpDelete]
        public HttpResponseMessage DeleteStudentEnrollment(int id)
        {
            var studentEnrollment = db.Students.Where(k => k.StudentId == id).SingleOrDefault();
            try
            {
                if (studentEnrollment != null)
                {
                    db.Students.Attach(studentEnrollment);
                    db.Students.Remove(studentEnrollment);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, studentEnrollment);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Enrollment information found");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }

        }
    }
}
