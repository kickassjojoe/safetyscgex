using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class LoginRequest {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Action { get; set; }
        public string Id { get; set; }
        public string EnvCode { get; set; }
        public string ProjectCode { get; set; }
    }
}
