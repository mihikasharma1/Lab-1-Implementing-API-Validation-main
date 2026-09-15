using System.ComponentModel.DataAnnotations;
using HealthcareApi.Validation;

namespace HealthcareApi.Models;

[ValidAppointmentTime]
public class AppointmentDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Patient name is required")]
    [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters")]
    public string PatientName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date is required")]
    [FutureDate] 
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    [Range(15, 120, ErrorMessage = "Duration must be between 15 and 120 minutes")]
    public int DurationMinutes { get; set; }
}