using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseService.Models;

namespace CourseService.Controllers
{
    public class BrandController : ApiController
    {
        static List<Brands> brands = new List<Brands>()
        {
            new Brands(){BrandId="B001",Name="Haro"},
            new Brands(){BrandId="B002",Name="Electra"},
            new Brands(){BrandId="B003",Name="Heller"},
            new Brands(){BrandId="B004",Name="Trek"}
        };

        public HttpResponseMessage Post([FromUri] Brands brand)
        {
            brands.Add(brand);
            return Request.CreateResponse(HttpStatusCode.OK, brand);
        }
    }
}
