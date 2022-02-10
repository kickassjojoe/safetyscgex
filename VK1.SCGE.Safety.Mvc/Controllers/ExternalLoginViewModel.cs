using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class ExternalLoginViewModel {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
