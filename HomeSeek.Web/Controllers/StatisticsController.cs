using HomeSeek.Database;
using HomeSeek.Repository;
using HomeSeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSeek.Web.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult ShowAllStatistics()
        {
            Statistics vm = new Statistics();
            UnitOfWork db = new UnitOfWork(new MyDatabase());

            var reservations = db.Reservations.GetAll();
            var places = db.Places.GetAll();
            var reviews = db.Reviews.GetAll();
            var users = db.Users.GetAll();
            var addresses = db.Address.GetAll();

            
            vm.TotalPlaces = places.Count();

            vm.TotalReviews = reviews.Count();
            vm.TotalReservations = reservations.Count();
            vm.TotalUsers = users.Count();
            vm.TotalAddresses = addresses.Count();

            return View(vm);
        }
    }
}