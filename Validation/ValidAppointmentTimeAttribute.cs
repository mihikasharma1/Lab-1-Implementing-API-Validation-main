using System.ComponentModel.DataAnnotations;
using HealthcareApi.Models;

namespace HealthcareApi.Validation;

public class ValidAppointmentTimeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not AppointmentDto dto)
            return ValidationResult.Success;

        if (dto.DurationMinutes > 60)
        {
            var hour = dto.Date.Hour;
            if (hour < 9 || hour >= 17)
            {
                return new ValidationResult(
                    "Appointments longer than 60 minutes must be booked between 9am and 5pm",
                    new[] { nameof(dto.Date) });
            }
        }

        return ValidationResult.Success;
    }
}

