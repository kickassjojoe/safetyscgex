using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
   public  class Employee {
        [Key,Required,StringLength(11)]
        public string EmployeeCode { get; set; }

        [StringLength(100)]
        public string NameTH { get; set; }

        [StringLength(100)]
        public string NameEN { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(100)]
        public string BusinessUnitLevel2 { get; set; }

        [StringLength(100)]
        public string BusinessUnitLevel3 { get; set; }

        [StringLength(100)]
        public string BusinessUnitLevel4 { get; set; }

        [StringLength(100)]
        public string BusinessUnitLevel5 { get; set; }

        [StringLength(100)]
        public string BusinessUnitLevel6 { get; set; }

        [StringLength(100)]
        public string Division { get; set; }

        [StringLength(100)]
        public string Branch { get; set; }

        [StringLength(100)]
        public string BranchCode { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string SupervisorCode { get; set; }

        [StringLength(100)]
        public string SupervisorEmail { get; set; }

        [StringLength(100)]
        public string SupervisorPosition { get; set; }

        [JsonIgnore]
        public virtual ICollection<TruckInspectionCard> TruckInspectionCards { get; set; } = new HashSet<TruckInspectionCard>();

    }
}
