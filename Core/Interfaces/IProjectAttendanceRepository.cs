using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProjectAttendanceRepository
    {
        Task<List<ProjectAttendance>> GetAttendeesAsync();

        Task<ProjectAttendance> GetAttendeesByIdAsync(int id);
    }
}
