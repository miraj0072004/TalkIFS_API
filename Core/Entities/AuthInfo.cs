using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class AuthInfo
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string id_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
