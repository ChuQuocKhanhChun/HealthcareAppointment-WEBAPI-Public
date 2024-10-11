using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public  class AppointmentsController:ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;
        public AppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentsService=appointmentsService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return Ok(await _appointmentsService.GetAppointmentsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(Guid id)
        {
            var appointment = await _appointmentsService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            await _appointmentsService.AddAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(Guid id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id)
                return BadRequest();
            await _appointmentsService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public async Task<ActionResult> CancelAppointment(Guid id)
        {
            await _appointmentsService.CancelAppointmentAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(Guid id)
        {
            await _appointmentsService.CancelAppointmentAsync(id);
            return NoContent();
        }
    }
}
