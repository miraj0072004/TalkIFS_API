using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class BaseEntity
    {
        public string Luname { get; set; }
        public string Keyref { get; set; }
        public object Objgrants { get; set; }
        public string Objkey { get; set; }
    }
}
