using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendDecot.Models
{
    public class User
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string birthdate { get; set; } //Date?
        public DateTime last_access_time { get; set; }
    }
}