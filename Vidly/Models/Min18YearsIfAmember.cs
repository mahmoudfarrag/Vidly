using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAmember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTybeId == MembershipTybe.Unknown || customer.MembershipTybeId == MembershipTybe.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is Requried");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success 
                : new ValidationResult("customer should be at least 18 years old to go a membership");
        }
    }
}