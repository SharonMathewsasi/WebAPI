using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class TainerController : ApiController
    {
        LearnTodayWebAPIDbEntities1 db = new LearnTodayWebAPIDbEntities1();

        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody] Trainer model)
        {

            try
            {
                db.Trainers.Add(model);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }
        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id, [FromBody] Trainer model)
        {
            var passwordGetUsingId = db.Trainers.Where(l => l.TrainerId == id).SingleOrDefault();
            try
            {
                if (passwordGetUsingId != null)
                {

                    db.Trainers.Remove(passwordGetUsingId);
                    db.Trainers.Add(model);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
