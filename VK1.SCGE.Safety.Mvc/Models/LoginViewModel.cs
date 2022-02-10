﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models {
    public class LoginViewModel {
        [Required(ErrorMessage = "Please provide a valid user name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide a valid password."), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
