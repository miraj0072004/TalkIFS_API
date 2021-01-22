using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class ProjectAttendance : BaseEntity
    {
        
        public double? Cf_Hours { get; set; }
        public string Cf_Name { get; set; }
        public string Cf_Project { get; set; }
        public DateTime Cf_Sign_In_Time { get; set; }
        public DateTime? Cf_Sign_Out_Time { get; set; }
        public string Cf_Status { get; set; }
        public string Cf_Terminal { get; set; }
        public string Cf_Terminal_O { get; set; }
    }
}
