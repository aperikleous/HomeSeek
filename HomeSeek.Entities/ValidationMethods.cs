using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Entities
{
    public class ValidationMethods
    {

        public static ValidationResult ValidateGreateOrEqualToZero(decimal value, ValidationContext context)
        {
            bool isValid = true;

            if (value < 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format("The field {0} must be greater than or equal to zero.", context.MemberName), new List<string> { context.MemberName });
            }
        }

        public static ValidationResult GreaterThanZero(int value, ValidationContext validationContext)
        {

            if (value > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                //return new ValidationResult(errorMessage: "Value should be greater than 0!");
                return new ValidationResult(string.Format("The field {0} must be greater than zero", validationContext.MemberName), new List<string> { validationContext.MemberName });
            }
        }

        public static ValidationResult MaxWords(string value, ValidationContext validationContext)
        {


            int wordCount = value.Split(' ').Length;
            if (wordCount <= 1500)
            {
                return ValidationResult.Success;
            }
            else
            {
                //return new ValidationResult(errorMessage: "Value should be greater than 0!");
                return new ValidationResult(string.Format("Comments should contain 150 or less words"), new List<string> { validationContext.MemberName });
            }
        }
    }
}
