using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class LoginResponse {
        public string AuthenResult { get; set; }
        public string AuthenCode { get; set; }
        public string Token { get; set; }
        public string MobileWebRefer { get; set; }
        public string MobileWebToken { get; set; }
        public bool IsForceChange { get; set; }
        public string IsAllowCheckIn { get; set; }
        public string IsHBM { get; set; }
    }
}
