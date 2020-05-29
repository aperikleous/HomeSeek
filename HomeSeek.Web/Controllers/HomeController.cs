using HomeSeek.Database;
using HomeSeek.Repository;
using HomeSeek.Web.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSeek.Web.Controllers
{
    public class HomeController : Controller
    {
        Statistics vm = new Statistics();
        UnitOfWork db = new UnitOfWork(new MyDatabase());

        public ActionResult Index()
        {
            var places = db.Places.GetAll();
            var reservations = db.Reservations.GetAll();
            var reviews = db.Reviews.GetAll();
            var photos = db.Photo.GetAll();
            ViewBag.AllPlaces = places.Count();
            ViewBag.AllReservations = reservations.Count();
            ViewBag.AllReviews = reviews.Count();
            ViewBag.AllPhotos = photos.Count();
            return View();
        }
        //Live Chat ActionMethod
        public ActionResult Chat()
        {
            return View();
        }
    }
}