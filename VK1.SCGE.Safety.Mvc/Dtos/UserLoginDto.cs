using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class UserLoginDto {
        [Required(ErrorMessage ="กรุณากรอก user name")]
        public string Username { get; set; }

        [Required(ErrorMessage ="กรุณากรอก password")]
        public string Password { get; set; }
    }
}
