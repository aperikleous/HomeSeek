using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeSeek.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public int Accuracy { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public int Checkin { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public int Cleanliness { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public int Location { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public int Value { get; set; }
        public DateTime SubDate { get; set; }
        [Range(0, 10, ErrorMessage = "Values should be between 0 - 10.")]
        public double OverallRating { get; set; }
        [DataType(DataType.Text), CustomValidation(typeof(ValidationMethods), "MaxWords")]
        public string Comment { get; set; }


        //Navigation Properties
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Place Place { get; set; }
    }
}