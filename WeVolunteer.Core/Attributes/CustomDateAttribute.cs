﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Core.Attributes
{
    public class CustomDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            // This assumes inclusivity, i.e. exactly six years ago is okay
            if (DateTime.Now.AddYears(-100).CompareTo(value) <= 0 && DateTime.Now.CompareTo(value) >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Enter a valid date.");
            }
        }
    }
}
