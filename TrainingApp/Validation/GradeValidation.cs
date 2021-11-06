using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingApp.Validation
{
    public class GradeValidation : ValidationAttribute
    {
        public string [] allowedString { set; get; } 

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            allowedString = new string[] {"Passed", "Failed" };

            if (allowedString.Contains(value))
            {
               return ValidationResult.Success;
            }
            return new ValidationResult("Invalid Grade score...");
        }
    }
}