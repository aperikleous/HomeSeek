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
        double _overallRating;
        public int ReviewId { get; set; }
        public int Identifier { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public int Accuracy { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public int Checkin { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public int Cleanliness { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public int Location { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public int Value { get; set; }
        public DateTime SubDate { get; set; }
        [Range(0, 5, ErrorMessage = "Values should be between 0 - 5.")]
        public double OverallRating {
            get
            {
                return this._overallRating;
            }
            set { this._overallRating = (this.Accuracy + this.Checkin + this.Cleanliness + this.Location + this.Value) / 5d; }
        }
        [DataType(DataType.Text), CustomValidation(typeof(ValidationMethods), "MaxWords")]
        public string Comment { get; set; }


        //Navigation Properties
       
        public int? PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}