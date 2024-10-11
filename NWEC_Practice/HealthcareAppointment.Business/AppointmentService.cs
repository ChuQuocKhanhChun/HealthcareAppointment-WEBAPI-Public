using HealthcareAppointment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task ScheduleAppointmentAsync(Appointment appointment)
        {
            // Add any scheduling validation logic here
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task CancelAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                appointment.Status = "Cancelled";
                await _appointmentRepository.UpdateAsync(appointment);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(int doctorId)
        {
            return await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(int patientId)
        {
            return await _appointmentRepository.GetAppointmentsByPatientIdAsync(patientId);
        }
    }

}

