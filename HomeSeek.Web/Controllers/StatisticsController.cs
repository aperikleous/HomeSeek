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
            List<string> cities = new List<string>();

            var reservations = db.Reservations.GetAll();
            var places = db.Places.GetAll();
            var reviews = db.Reviews.GetAll();
            var users = db.Users.GetAll();
            var addresses = db.Address.GetAll();

            vm.TotalPlaces = places.Count();

            vm.TotalReviews = reviews.Count();
            vm.TotalReservations = reservations.Count();
            vm.TotalUsers = users.Count();

            //--------------------------------------------
            foreach (var address in addresses)
            {
                cities.Add(address.City);
                Console.WriteLine(address.City);
            }
            vm.TotalCities = cities.Count();
            //----------------------------------------------------------------
            int totalDays = 0;
            for (int i = 0; i < reservations.Count(); i++)
            {
                totalDays += reservations[i].DaysOfStaying;
            }
            double avgDays = totalDays / reservations.Count();
            vm.AvgTotalDays = avgDays;
           
            //----------------------------------------------------------------
            
            int Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec;
            Jan = Feb = Mar = Apr = May = Jun = Jul = Aug = Sep = Oct = Nov = Dec = 0;
            Dictionary<string, int> perMonth = new Dictionary<string, int>();
            foreach (var reservation in reservations)
            {
                switch (reservation.PaymentDate.Month)
                {
                    case 1:
                        Jan += 1;
                        break;
                    case 2:
                        Feb += 1;
                        break;
                    case 3:
                        Mar += 1;
                        break;
                    case 4:
                        Apr += 1;
                        break;
                    case 5:
                        May += 1;
                        break;
                    case 6:
                        Jun += 1;
                        break;
                    case 7:
                        Jul += 1;
                        break;
                    case 8:
                        Aug += 1;
                        break;
                    case 9:
                        Sep += 1;
                        break;
                    case 10:
                        Oct += 1;
                        break;
                    case 11:
                        Nov += 1;
                        break;
                    case 12:
                        Dec += 1;
                        break;
                }//end switch
            }//end foreach
            perMonth.Add("Jan", Jan); perMonth.Add("Feb", Feb); perMonth.Add("Mar", Mar); perMonth.Add("Apr", Apr); perMonth.Add("May", May); perMonth.Add("Jun", Jun);
            perMonth.Add("Jul", Jul); perMonth.Add("Aug", Aug); perMonth.Add("Sep", Sep); perMonth.Add("Oct", Oct); perMonth.Add("Nov", Nov); perMonth.Add("Dec", Dec);
            vm.ReservPerMonth = perMonth;

            //----------------------------- overall rating per place ---------------------------------------
            Dictionary<string, double> ratingPlace = new Dictionary<string, double>();
            foreach (var place in places)
            {
                var overallSumRatingPlace = 0d;
                foreach (var review in place.Reviews)
                {
                    overallSumRatingPlace += review.OverallRating;
                }
                double overallRatingPlace = overallSumRatingPlace / place.Reviews.Count();

                ratingPlace.Add(place.ApartmentName, overallRatingPlace);
            }
            vm.OverallRatingPlace = ratingPlace;
            //----------------------------------- places per city ----------------------
            Dictionary<string, int> placesInCity = new Dictionary<string, int>();
            foreach (var address in addresses)
            {
                var placesCount = 0;
                foreach (var place in address.Places)
                {
                    placesCount += 1;
                }
                placesInCity.Add(address.City, placesCount);
            }
            vm.PlacesPerCity = placesInCity;
                return View(vm);
        }
    }
}