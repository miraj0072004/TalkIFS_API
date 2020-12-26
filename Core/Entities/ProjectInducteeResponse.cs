using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;

namespace Core.Entities
{
    public class ProjectInducteeResponse 
    {
        public string Context { get; set; }
        public IList<ProjectInductee> value { get; set; }
    }
}
