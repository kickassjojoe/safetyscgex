using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class TruckInspectionCardAddDto {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int StartOdometer { get; set; }
        public string Vehicle { get; set; }
        public List<UserData> UserData { get; set; }
    }
    public class UserData {
        public int CategoryId { get; set; }
        public int TruckInspectionId { get; set; }
        public string TruckInspectionName { get; set; }
        public bool IsMust { get; set; }
        public string IsNormal { get; set; }
        public string Remark { get; set; }
        public string File { get; set; }
    }
}
