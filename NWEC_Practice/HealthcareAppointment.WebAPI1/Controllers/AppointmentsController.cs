using HealthcareAppointment.Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    // GET /appointments
    [HttpGet]
    public ActionResult<IEnumerable<Appointment>> GetAppointments()
    {
        var appointments = _appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    // GET /appointments/{id}
    [HttpGet("{id}")]
    public ActionResult<Appointment> GetAppointment(int id)
    {
        var appointment = _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    // POST /appointments
    [HttpPost]
    public ActionResult<Appointment> CreateAppointment([FromBody] Appointment appointmentDto)
    {
        var appointment = _appointmentService.ScheduleAppointmentAsync(appointmentDto);
        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    // PUT /appointments/{id}
    [HttpPut("{id}")]
    public ActionResult<Appointment> UpdateAppointment(int id, [FromBody] Appointment updateDto)
    {
        var appointment = _appointmentService.UpdateAppointmentAsync( updateDto);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    // DELETE /appointments/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteAppointment(int id)
    {
        var result = _appointmentService.CancelAppointmentAsync(id);
        
        return NoContent();
    }

    // PATCH /appointments/{id}/cancel
    [HttpPatch("{id}/cancel")]
    public ActionResult CancelAppointment(int id)
    {
        var appointment = _appointmentService.CancelAppointmentAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    // GET /doctors/{doctorId}/search
    [HttpGet("doctors/{doctorId}/search")]
    public ActionResult<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var appointments = _appointmentService. GetAppointmentsForDoctorAsync(doctorId);
        return Ok(appointments);
    }
}
