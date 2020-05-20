using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeSeek.Web.Models
{
    public class Statistics
    {
        [Display(Name="Total Places")]
        public int TotalPlaces { get; set; }
        [Display(Name = "Total Reviews")]
        public int TotalReviews { get; set; }
        [Display(Name = "Total Reservations")]
        public int TotalReservations { get; set; }
        [Display(Name = "Total Users")]
        public int TotalUsers { get; set; }
        [Display(Name = "Total Cities")]
        public int TotalCities { get; set; }
        [Display(Name = "Average days of staying of All Listings")]
        public double AvgTotalDays { get; set; }
        [Display(Name = "Reservations per Month")]
        public Dictionary<string,int> ReservPerMonth { get; set; }


    }
}