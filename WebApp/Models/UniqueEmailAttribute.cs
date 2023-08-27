using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var dbContext = validationContext.GetService(typeof(DbContext)) as DbContext;
                var propertyName = validationContext.MemberName;
                var existingUser = dbContext.Set<User>().FirstOrDefault(u => u.Email == (string)value);

                if (existingUser != null)
                {
                    return new ValidationResult($"The email '{value}' is already in use.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
