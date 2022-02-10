using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class PartTwo : ModelBase {
        public int PartTwoId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        public TimeSpan? LeaveBranchTime { get; set; }

        public int? LeisureHour { get; set; }

        public IncidentRoute IncidentRoute { get; set; }  // enum

        public bool IsProduct { get; set; }

        public int? ProductQty { get; set; }

        public bool IsProductDamage { get; set; }

        public int? ProductDamageQty { get; set; }

        public decimal? ProductDamageValue { get; set; }

        public CaseEffect CaseEffect { get; set; }   // enum

        public int? ProductPostpone { get; set; }

        public CaseInjure EmpInjure { get; set; }  // enum

        [StringLength(500)]
        public string EmpInjureDescription { get; set; }

        public int? StopWorking { get; set; }

        public CaseInjure PartiesInjure { get; set; }  // enum

        [StringLength(500)]
        public string PartiesInjureDescription { get; set; }

        public int? PartiesDie { get; set; }

        public CaseInjure ThirdPartiesInjure { get; set; }  // enum

        [StringLength(500)]
        public string ThirdPartiesInjureDescription { get; set; }

        public int? ThirdPartiesDie { get; set; }

        public CaseDamage TruckDamage { get; set; }  // enum

        [StringLength(500)]
        public string TruckDamageDescription { get; set; }

        public CaseDamage PartiesDamage { get; set; }  // enum

        [StringLength(500)]
        public string PartiesDamageDescription { get; set; }

        public CaseDamage EquipmentDamage { get; set; }  // enum

        [StringLength(500)]
        public string EquipmentDamageDescription { get; set; }

        public CaseCamera Camera { get; set; }   // enum

        public bool IsTruckInspectionNormal { get; set; }

        [StringLength(500)]
        public string TruckInspectionDescription { get; set; }

        public bool IsGps { get; set; }

        public int? GpsSpeed { get; set; }

        public int? GpsSpeedLimit { get; set; }

        public bool IsCctv { get; set; }

        public bool IsPassAlcohol { get; set; }
        public bool IsPassSafetyCourse { get; set; }
        public bool IsPassSDC { get; set; }

        public CaseTraining? Training { get; set; } //enum

        public DateTime? LastMaintenanceDate { get; set; }
        public int? LastMaintenanceOdometer { get; set; }
    }
}
