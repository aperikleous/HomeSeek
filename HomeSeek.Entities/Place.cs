using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeSeek.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        [Required, StringLength(150, MinimumLength = 2, ErrorMessage = "Apartment Name must contain min2 characters & max 150")]
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }
        [Required, MinLength(15, ErrorMessage = "Description must contain minimum 10 characters")]
        public string Description { get; set; }
        [Required, Range(1, 20)]
        public int Guests { get; set; }
        [Required, Range(1, 10)]
        public int Bedroom { get; set; }
        [Required, Range(1, 12)]
        public int Bathroom { get; set; }
        [Required, CustomValidation(typeof(ValidationMethods), "ValidateGreateOrEqualToZero")]
        public decimal PricePerDay { get; set; }
        [CustomValidation(typeof(ValidationMethods), "ValidateGreateOrEqualToZero")]
        public decimal CleanCost { get; set; }
        public bool IsBooked { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }


        //Navigation Properties
        public virtual Amenities Amenities { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        [Required]
        public virtual Address Address { get; set; }
    }
}
