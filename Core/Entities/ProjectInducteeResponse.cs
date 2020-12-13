using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProjectInducteeResponse: BaseResponse
    {
        public IList<ProjectInductee> value { get; set; }
    }
}
