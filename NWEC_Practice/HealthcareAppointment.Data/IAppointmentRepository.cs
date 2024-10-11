using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        // Additional methods specific to Appointment repository
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);
    }
}
