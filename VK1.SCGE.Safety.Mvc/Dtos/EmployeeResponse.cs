using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class EmployeeResponse {
        public string EmployeeCode { get; set; }
        public string NameTH { get; set; }
        public string NameEN { get; set; }
        public string Position { get; set; }
        public string BusinessUnitLevel2 { get; set; }
        public string BusinessUnitLevel3 { get; set; }
        public string BusinessUnitLevel4 { get; set; }
        public string BusinessUnitLevel5 { get; set; }
        public string BusinessUnitLevel6 { get; set; }
        public string Division { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Email { get; set; }
        public string SupervisorCode { get; set; }
        public string SupervisorEmail { get; set; }
        public string SupervisorPosition { get; set; }

    }
}
