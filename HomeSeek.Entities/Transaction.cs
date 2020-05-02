using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSeek.Entities
{
    public class Transaction
    {
        [ForeignKey("Reservation")]
        public int TransactionId { get; set; }
        [Required, Display(Name = "Payment Time")]
        public DateTime PaymentDate { get; set; }
        [Required, Display(Name = "Total Amount"), DataType(DataType.Currency, ErrorMessage = "Total amount should contain only numbers."), CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        public decimal TotalAmount { get; set; }
        [Required, Display(Name = "Total Fees"), DataType(DataType.Currency, ErrorMessage = "Total fees should contain only numbers."), CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        public decimal TotalFees { get; set; }
        //[Required, Display(Name = "Tax"), DataType(DataType.Currency, ErrorMessage = "Tax should contain only numbers."), CustomValidation(typeof(ValidationMethods), "GreaterThanZero")]
        //public int Vat { get; set; }


        //Navigation Properties
        public virtual Reservation Reservation { get; set; }
    }
}