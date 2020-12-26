using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProjectAttendanceRepository
    {
        Task<List<ProjectAttendance>> GetAttendancesAsync(string url, string token, string inducteeName);

        Task<ProjectAttendance> CreateAttendanceAsync(string url, string token, ProjectAttendance projectAttendance);

        Task<ProjectAttendance> UpdateAttendanceAsync(string url, string token, ProjectAttendance projectAttendance);

        //Task<List<ProjectAttendance>> GetAttendencesByInducteeAsync(string url, string token, string inducteeName);
    }
}
