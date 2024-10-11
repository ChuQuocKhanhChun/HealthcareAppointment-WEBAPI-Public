using HealthcareAppointment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public interface IUserRepository : IRepository<User>
    {
        // Additional methods specific to User repository
        Task<IEnumerable<User>> GetDoctorsAsync();
        Task<IEnumerable<User>> GetPatientsAsync();
    }

}
