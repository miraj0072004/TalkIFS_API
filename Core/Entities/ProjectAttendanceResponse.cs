using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;

namespace Core.Entities
{
    public class ProjectAttendanceResponse 
    {
        public string Context { get; set; }
        public IList<ProjectAttendance> value { get; set; }
    }
}
