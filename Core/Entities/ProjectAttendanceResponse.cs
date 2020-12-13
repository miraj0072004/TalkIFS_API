using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProjectAttendanceResponse:BaseResponse
    {
        public IList<ProjectAttendance> value { get; set; }
    }
}
