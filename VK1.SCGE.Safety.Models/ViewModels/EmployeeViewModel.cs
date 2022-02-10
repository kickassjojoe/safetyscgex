using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
   public class EmployeeViewModel {
        public string scg_employee_id { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public string position { get; set; }
        public string BusinessUnit_Level2 { get; set; }
        public string BusinessUnit_Level3 { get; set; }
        public string BusinessUnit_Level4 { get; set; }
        public string BusinessUnit_Level5 { get; set; }
        public string BusinessUnit_Level6 { get; set; }
        public string division { get; set; }
        public string branch { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string Email { get; set; }
        public string SupervisorCode { get; set; }
        public string SupervisorEmail { get; set; }
        public string SupervisorPosition { get; set; }
    }
}
