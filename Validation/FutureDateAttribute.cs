using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Validation;

public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute()
    {
        ErrorMessage = "The appointment date must be in the future";
    }

    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
        {
            return date > DateTime.Now;
        }
        return true; // let [Required] handle null
    }
}
