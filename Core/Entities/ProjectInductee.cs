using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProjectInductee : BaseEntity
    {
        public string Cf_Company { get; set; }
        public string Cf_Date_Completed { get; set; }
        public bool Cf_Holds_High_Risk_Lic { get; set; }
        public string Cf_Induction_Number { get; set; }
        public string Cf_Name { get; set; }
        public object Cf_Person_Id { get; set; }
        public string Cf_Project { get; set; }
        public bool Cf_Questionnaire_Attached { get; set; }
        public bool Cf_Tickets_Attached { get; set; }
    }
}
