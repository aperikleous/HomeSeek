﻿using HomeSeek.Database;
using HomeSeek.Repository;
using HomeSeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Rest.Api.V2010.Account.Usage.Record;

namespace HomeSeek.Web.Controllers
{
    public class AdministratorController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MyDatabase());
        [Authorize(Roles="Admin")]
        public ActionResult Index()
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

            // --------------------------------------------
            foreach (var address in addresses)
            {
                cities.Add(address.City);
                Console.WriteLine(address.City);
            }
            vm.TotalCities = cities.Count();
            // ----------------------------------------------------------------
            int totalDays = 0;
            for (int i = 0; i < reservations.Count(); i++)
            {
                totalDays += reservations[i].DaysOfStaying;
            }
            double avgDays = totalDays / reservations.Count();
            vm.AvgTotalDays = avgDays;

            // ----------------------------------------------------------------

            //int Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec;
            //Jan = Feb = Mar = Apr = May = Jun = Jul = Aug = Sep = Oct = Nov = Dec = 0;
            //Dictionary<string, int> perMonth = new Dictionary<string, int>();
            //foreach (var reservation in reservations)
            //{
            //    //switch (reservation.PaymentDate.Month)
            //    switch (reservation.CheckOutDate.Month)
            //    {
            //        case 1:
            //            Jan += 1;
            //            break;
            //        case 2:
            //            Feb += 1;
            //            break;
            //        case 3:
            //            Mar += 1;
            //            break;
            //        case 4:
            //            Apr += 1;
            //            break;
            //        case 5:
            //            May += 1;
            //            break;
            //        case 6:
            //            Jun += 1;
            //            break;
            //        case 7:
            //            Jul += 1;
            //            break;
            //        case 8:
            //            Aug += 1;
            //            break;
            //        case 9:
            //            Sep += 1;
            //            break;
            //        case 10:
            //            Oct += 1;
            //            break;
            //        case 11:
            //            Nov += 1;
            //            break;
            //        case 12:
            //            Dec += 1;
            //            break;
            //    }//end switch
            //}//end foreach
            ////perMonth.Add("Jan", Jan); perMonth.Add("Feb", Feb); perMonth.Add("Mar", Mar); perMonth.Add("Apr", Apr); perMonth.Add("May", May); perMonth.Add("Jun", Jun);
            ////perMonth.Add("Jul", Jul); perMonth.Add("Aug", Aug); perMonth.Add("Sep", Sep); perMonth.Add("Oct", Oct); perMonth.Add("Nov", Nov); perMonth.Add("Dec", Dec);
            ////var RPM = vm.ReservPerMonth = perMonth;

            //// -----------------------------overall rating per place-------------------------------------- -
            //Dictionary<string, double> ratingPlace = new Dictionary<string, double>();
            //Dictionary<string, double> accuracy = new Dictionary<string, double>();
            //Dictionary<string, double> checkin = new Dictionary<string, double>();
            //Dictionary<string, double> cleanliness = new Dictionary<string, double>();
            //Dictionary<string, double> location = new Dictionary<string, double>();
            //Dictionary<string, double> value = new Dictionary<string, double>();
            //Dictionary<string, int> reviewsPlace = new Dictionary<string, int>();
            //Dictionary<string, int> reservationsPlace = new Dictionary<string, int>();

            //foreach (var place in places)
            //{
            //    var overallSumRatingPlace = 0d;
            //    var totalValue = 0d;
            //    var totalAccuracy = 0d;
            //    var totalCheckin = 0d;
            //    var totalCleanliness = 0d;
            //    var totalLocation = 0d;
            //    var totalReviews = 0;
            //    var totalReservations = 0;
            //    foreach (var review in place.Reviews)
            //    {
            //        totalReviews += 1;
            //        overallSumRatingPlace += review.OverallRating;
            //        totalAccuracy = review.Accuracy;
            //        totalCheckin = review.Checkin;
            //        totalCleanliness = review.Cleanliness;
            //        totalLocation = review.Location;
            //        totalValue = review.Value;
            //    }
            //    foreach (var reservation in place.Reservations)
            //    {
            //        totalReservations += 1;
            //    }
            //    double overallRatingPlace = overallSumRatingPlace / place.Reviews.Count();
            //    double avgAccuracy = totalAccuracy / place.Reviews.Count();
            //    double avgCheckin = totalCheckin / place.Reviews.Count();
            //    double avgCleanliness = totalCleanliness / place.Reviews.Count();
            //    double avgLocation = totalLocation / place.Reviews.Count();
            //    double avgValue = totalValue / place.Reviews.Count();

            //    ratingPlace.Add(place.ApartmentName, overallRatingPlace);
            //    accuracy.Add(place.ApartmentName, avgAccuracy);
            //    checkin.Add(place.ApartmentName, avgCheckin);
            //    cleanliness.Add(place.ApartmentName, avgCleanliness);
            //    location.Add(place.ApartmentName, avgLocation);
            //    value.Add(place.ApartmentName, avgValue);
            //    reviewsPlace.Add(place.ApartmentName, totalReviews);
            //    reservationsPlace.Add(place.ApartmentName, totalReservations);
            //}
            //vm.OverallRatingPlace = ratingPlace;
            //vm.avgAccuracy = accuracy;
            //vm.avgCheckin = checkin;
            //vm.avgCleanliness = cleanliness;
            //vm.avgLocation = location;
            //vm.avgValue = value;
            //vm.ReviewsPerPlace = reviewsPlace;
            //vm.ReservationsPerPlace = reservationsPlace;

            //// -----------------------------------places per city ----------------------
            //Dictionary<string, int> placesInCity = new Dictionary<string, int>();
            //foreach (var address in addresses)
            //{
            //    var placesCount = 0;
            //    foreach (var place in address.Places)
            //    {
            //        placesCount += 1;
            //    }
            //    placesInCity.Add(address.City, placesCount);
            //}
            //vm.PlacesPerCity = placesInCity;
            //------------------------------Reservations per place ---------------------------------------

            return View(vm);
        }


        // GET: Administrator
        public JsonResult Statistics()
        {
            Statistics vm = new Statistics();
            UnitOfWork db = new UnitOfWork(new MyDatabase());
            List<string> cities = new List<string>();

            var reservations = db.Reservations.GetAll();
            var places = db.Places.GetAll();
            var reviews = db.Reviews.GetAll();
            var users = db.Users.GetAll();
            var addresses = db.Address.GetAll();
            //  Dictionary<string,decimal> lat = new Dictionary<string,decimal>();
            // Dictionary<string,decimal> longi = new Dictionary<string,decimal>();
            decimal[] lat = new decimal[addresses.Count()];
            decimal[] longi = new decimal[addresses.Count()];
            for (int i = 0; i < addresses.Count(); i++)
            {
                lat[i] = Convert.ToDecimal(addresses[i].Latitude, CultureInfo.InvariantCulture);
                longi[i] = Convert.ToDecimal(addresses[i].Longitude, CultureInfo.InvariantCulture);
            }
            
            //vm.Coordinates = coord;
            vm.Lat = lat;
            vm.Long = longi;

            vm.TotalPlaces = places.Count();

            vm.TotalReviews = reviews.Count();
            vm.TotalReservations = reservations.Count();
            vm.TotalUsers = users.Count();

            int Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec;
            Jan = Feb = Mar = Apr = May = Jun = Jul = Aug = Sep = Oct = Nov = Dec = 0;
            //Dictionary<string, int> perMonth = new Dictionary<string, int>();
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


            int Jan1, Feb1, Mar1, Apr1, May1, Jun1, Jul1, Aug1, Sep1, Oct1, Nov1, Dec1;
            Jan1 = Feb1 = Mar1 = Apr1 = May1 = Jun1 = Jul1 = Aug1 = Sep1 = Oct1 = Nov1 = Dec1 = 0;

            foreach (var review in reviews)
            {
                switch (review.SubDate.Month)
                {
                    case 1:
                        Jan1 += 1;
                        break;
                    case 2:
                        Feb1 += 1;
                        break;
                    case 3:
                        Mar1 += 1;
                        break;
                    case 4:
                        Apr1 += 1;
                        break;
                    case 5:
                        May1 += 1;
                        break;
                    case 6:
                        Jun1 += 1;
                        break;
                    case 7:
                        Jul1 += 1;
                        break;
                    case 8:
                        Aug1 += 1;
                        break;
                    case 9:
                        Sep1 += 1;
                        break;
                    case 10:
                        Oct1 += 1;
                        break;
                    case 11:
                        Nov1 += 1;
                        break;
                    case 12:
                        Dec1 += 1;
                        break;
                }//end switch
            }
            List<int> reviewMonth = new List<int>() { Jan1, Feb1, Mar1, Apr1, May1, Jun1, Jul1, Aug1, Sep1, Oct1, Nov1, Dec1 };
            vm.ReviewsPerMonth = reviewMonth;
            List<int> reserve = new List<int>() { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
            var RPM = vm.ReservPerMonth = reserve;


            //// -----------------------------overall rating per place-------------------------------------- -
            Dictionary<string, double> ratingPlace = new Dictionary<string, double>();
            Dictionary<string, double> accuracy = new Dictionary<string, double>();
            Dictionary<string, double> checkin = new Dictionary<string, double>();
            Dictionary<string, double> cleanliness = new Dictionary<string, double>();
            Dictionary<string, double> location = new Dictionary<string, double>();
            Dictionary<string, double> value = new Dictionary<string, double>();
            // Dictionary<string, int> reviewsPlace = new Dictionary<string, int>();
            // Dictionary<string, int> reservationsPlace = new Dictionary<string, int>();

            foreach (var review in reviews)
            {

            }

            foreach (var place in places)
            {
                var overallSumRatingPlace = 0d;
                var totalValue = 0d;
                var totalAccuracy = 0d;
                var totalCheckin = 0d;
                var totalCleanliness = 0d;
                var totalLocation = 0d;
                var totalReviews = 0;
                var totalReservations = 0;
                foreach (var review in place.Reviews)
                {
                    totalReviews += 1;
                    overallSumRatingPlace += review.OverallRating;
                    totalAccuracy = review.Accuracy;
                    totalCheckin = review.Checkin;
                    totalCleanliness = review.Cleanliness;
                    totalLocation = review.Location;
                    totalValue = review.Value;
                }
                foreach (var reservation in place.Reservations)
                {
                    totalReservations += 1;
                }
                double overallRatingPlace = 0d;
                double avgAccuracy = 0d;
                double avgCheckin = 0d;
                double avgCleanliness = 0d;
                double avgLocation = 0d;
                double avgValue = 0d;


                ratingPlace.Add(place.ApartmentName, overallRatingPlace);
                accuracy.Add(place.ApartmentName, avgAccuracy);
                checkin.Add(place.ApartmentName, avgCheckin);
                cleanliness.Add(place.ApartmentName, avgCleanliness);
                location.Add(place.ApartmentName, avgLocation);
                value.Add(place.ApartmentName, avgValue);
                //reviewsPlace.Add(place.ApartmentName, totalReviews);
                //reservationsPlace.Add(place.ApartmentName, totalReservations);
            }
            //vm.OverallRatingPlace = ratingPlace.Values.Average();
            vm.OverallRatingPlace = reviews.Average(x => x.OverallRating);
            vm.avgAccuracy = reviews.Average(x => x.Accuracy);
            vm.avgCheckin = reviews.Average(x => x.Checkin);
            vm.avgCleanliness = reviews.Average(x => x.Cleanliness);
            vm.avgLocation = reviews.Average(x => x.Location);
            vm.avgValue = reviews.Average(x => x.Value);
            // vm.ReviewsPerPlace = reviewsPlace;
            // vm.ReservationsPerPlace = reservationsPlace;


            //------------------------------Reservations per place ---------------------------------------


            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public ActionResult View1()
        {
            return View();
        }

        //public JsonResult Charts()
        //{
        //    var reservationsPerMonth = db.Reservations.GetAll().Select(x=> new
        //    {
        //        date = x.
        //    })

        //    //var a = from i in reservationsPerMonth
        //    //        select new
        //    //        {
        //    //           year = i.CheckInDate.Year
        //    //        };

        //    return Json(reservationsPerMonth, JsonRequestBehavior.AllowGet);
        //}
    }
}