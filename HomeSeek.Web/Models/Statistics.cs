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
        [Display(Name = "Total Addresses")]
        public int TotalAddresses { get; set; }


    }
}