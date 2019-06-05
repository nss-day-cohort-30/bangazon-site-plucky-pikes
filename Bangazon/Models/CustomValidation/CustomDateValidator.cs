using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.CustomValidation
{
    public class CustomDateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            // if (value >= Convert.ToDateTime("01/10/1900").ToString() && value <= Convert.ToDateTime("01/12/2008"))
            DateTime pastDate = new DateTime(1900, 1, 1);
            DateTime newValue = Convert.ToDateTime(value);
            if (DateTime.Compare(pastDate, newValue) > 0 && DateTime.Compare(DateTime.Now, newValue) < 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not in given range.");
            }
        }
    }
}
