using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeSeek.Web.Models
{
    public class Statistics
    {
        [Display(Name = "Total Places")]
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
        public List<int> ReservPerMonth { get; set; }
        [Display(Name = "Overall Average rating per place")]
        public double OverallRatingPlace { get; set; }
        [Display(Name = "Places per city")]
        public Dictionary<string, int> PlacesPerCity { get; set; }
        [Display(Name = "Average Accuracy rating")]
        public double avgAccuracy { get; set; }
        [Display(Name = "Average Check-in rating")]
        public double avgCheckin { get; set; }
        [Display(Name = "Average Cleanliness rating")]
        public double avgCleanliness { get; set; }
        [Display(Name = "Average Location rating")]
        public double avgLocation { get; set; }
        [Display(Name = "Average Value rating")]
        public double avgValue { get; set; }
        [Display(Name = "Reviews per place")]
        public List<int> ReviewsPerMonth { get; set; }
        [Display(Name = "Reservations per place")]
        public Dictionary<string, int> ReservationsPerPlace { get; set; }
        public Dictionary<string, decimal> CoordLat { get; set; }
        public Dictionary<string, decimal> CoordLong { get; set; }
        public decimal[] Lat { get; set; }
        public decimal[] Long { get; set; }
        public List<string> Photos { get; set; }


    }
}