using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Data {
    public class ApplicationUser : IdentityUser {
        [Required]
        public string Name { get; set; }
    }
}
