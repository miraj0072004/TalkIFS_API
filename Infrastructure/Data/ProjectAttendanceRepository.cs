using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ProjectAttendanceRepository: IProjectAttendanceRepository
    {
        public Task<List<ProjectAttendance>> GetAttendeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectAttendance> GetAttendeesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
