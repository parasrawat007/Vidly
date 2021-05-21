using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == Customer.Unkown || 
                customer.MembershipTypeId==Customer.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate==null)
            {
                return new ValidationResult("Please Enter Your Birthdate");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ?ValidationResult.Success
                :new ValidationResult("Customer should be at least 18 year old to go on a membership");
        }
    }
}