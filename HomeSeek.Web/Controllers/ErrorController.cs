using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSeek.Web.Controllers
{
    
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}