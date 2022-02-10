using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models {
    public class UserViewModel {
        [Required(ErrorMessage = "Please provide a valid user name.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please provide a valid password.")]
        public string Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password")]
        [Required(ErrorMessage = "Please provide a valid confirm password.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please provide a valid name.")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please provide a valid email")]
        public string Email { get; set; }

        public List<SelectListItem> ApplicationRoles { get; set; }

        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }
    }
}
