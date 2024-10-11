using HealthcareAppointment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        HealthcareDbContext _context;
        public UserRepository(HealthcareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetDoctorsAsync()
        {
            return await _context.Users.Where(u => u.Role == "Doctor").ToListAsync();
        }

        public async Task<IEnumerable<User>> GetPatientsAsync()
        {
            return await _context.Users.Where(u => u.Role == "Patient").ToListAsync();
        }
    }

}
