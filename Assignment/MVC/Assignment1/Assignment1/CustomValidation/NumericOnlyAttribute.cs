using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Assignment1.CustomValidation
{

    public class NumericOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("ID is required");

            if (!Regex.IsMatch(value.ToString(), @"^\d+$"))
                return new ValidationResult("Only numeric values allowed");

            return ValidationResult.Success;
        }
    }
}
