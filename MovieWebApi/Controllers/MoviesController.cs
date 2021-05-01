using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MmovieWebApi.Controllers
{
    public class MoviesController : ApiController
    {
        //public string Get()
        //{
        // return "Hellofrom WEb API."
        //}



        [HttpGet]
        public List<string> GetMovies()
        {
            return new List<string> { "Titanic", "MI", "Matrix" };
        }
    }
}
