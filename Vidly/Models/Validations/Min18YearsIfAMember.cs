using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.Validations
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == null 
                    || customer.MembershipTypeId == MembershipType.Unknown 
                    || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else if (customer.BirthDate == null)
            {
                return new ValidationResult("Date of birth is required!");
            }
            else
            {
                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

                return (age >= 18) 
                    ? ValidationResult.Success 
                    : new ValidationResult("Customer must be at least 18 years old!") ;
            }
        }
    }
}
