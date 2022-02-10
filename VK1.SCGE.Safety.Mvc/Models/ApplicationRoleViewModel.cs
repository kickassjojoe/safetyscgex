using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models {
    public class ApplicationRoleViewModel {
        public string Id { get; set; }

        [Required, Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
