using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Entities
{
    public class Reservation :IValidatableObject
    {

        public int ReservationId { get; set; }
        [Required, Display(Name = "Check in date")]
        public DateTime CheckInDate { get; set; }
        [Required, Display(Name = "Check out date")]
        public DateTime CheckOutDate { get; set; }
        [CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        public int DaysOfStaying { get; set; }
        [Required, Display(Name = "Payment Time")]
        public DateTime PaymentDate { get; set; }
        [Required, Display(Name = "Total Amount"), DataType(DataType.Currency, ErrorMessage = "Total amount should contain only numbers."), CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        public decimal TotalAmount { get; set; }
        [ Display(Name = "Total Fees"), DataType(DataType.Currency, ErrorMessage = "Total fees should contain only numbers."), CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        public decimal TotalFees { get; set; }


        //Navigation Properties
        public int? PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        //Validation for Check out and Check in
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckOutDate < CheckInDate)
            {
                yield return new ValidationResult("Check out date can't be earlier than Check in.");
            }
        }

    }
}
