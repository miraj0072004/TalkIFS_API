using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class BaseEntity
    {
        [JsonProperty("@odata.etag")]
        public string ETag { get; set; }
        public string Luname { get; set; }
        public string Keyref { get; set; }
        public object Objgrants { get; set; }
        public string Objkey { get; set; }
    }
}
