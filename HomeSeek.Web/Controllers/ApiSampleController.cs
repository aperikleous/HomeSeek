using HomeSeek.Database;
using HomeSeek.Entities;
using HomeSeek.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml;

namespace HomeSeek.Web.Controllers
{
    public class ApiSampleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            UnitOfWork db = new UnitOfWork(new MyDatabase());
            var place = db.Places.GetAll();
            return Json(place, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

    }
}
