using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Validators
{
    public class DateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = "invalid date!";

            if (value != null && value is string && value.ToString().Length > 0)
            {
                string txtDate= value.ToString();
                DateTime tempDate;

                if(DateTime.TryParse(txtDate, out tempDate))
                {
                    if (tempDate > DateTime.Now)
                        return ValidationResult.Success;
                    else
                    {
                        errorMessage = "Only future date will be accepted";
                    }
                }
            }
            return new ValidationResult(errorMessage);
        }
    }
}
