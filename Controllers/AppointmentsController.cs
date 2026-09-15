using HealthcareApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private static readonly List<AppointmentDto> Appointments = new();

    [HttpGet]
    public ActionResult<IEnumerable<AppointmentDto>> GetAppointments()
    {
        return Ok(Appointments);
    }

    [HttpPost]
    public ActionResult<AppointmentDto> CreateAppointment(AppointmentDto appointment)
    {
        // TODO: Add ModelState.IsValid check here
        if (!ModelState.IsValid)
        {
            return BadRequest(CreateValidationErrorResponse());
        }
        
        // Assign a simple ID (this is bad practice - just for demo)
        appointment.Id = Appointments.Count + 1;
        Appointments.Add(appointment);
        
        // Return the appointment with the assigned ID
        return Ok(appointment);
    }
    
    private object CreateValidationErrorResponse()
    {
        var errors = ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        return new { message = "Validation failed", errors };
    }
}