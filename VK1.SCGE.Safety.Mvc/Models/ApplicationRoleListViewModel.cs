using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models {
    public class ApplicationRoleListViewModel {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
