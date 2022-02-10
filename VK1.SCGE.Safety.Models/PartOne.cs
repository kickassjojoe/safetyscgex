using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;
using System.Xml.Schema;

namespace VK1.SCGE.Safety.Models {
   public class PartOne : ModelBase {
        public int PartOneId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        [Required,StringLength(250)]
        public string CaseName { get; set; }

        [Required, StringLength(15)]
        [ForeignKey(nameof(Branch))]
        public string BranchCode { get; set; }
        public virtual Branch Branch { get; set; }

        [Required, StringLength(200)]
        public string BranchName { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        [Required, StringLength(150)]
        public string RegionName { get; set; }

        public DateTime CaseDate { get; set; }

        public TimeSpan CaseTime { get; set; }

        [Required,StringLength(250)]
        public string   CaseLocation { get; set; }

        //2021-02-24
        [StringLength(11)]
        public string EmployeeCode { get; set; } //free text

        [Required,StringLength(150)]
        public string EmployeeName { get; set; }  //free text

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
       
        [StringLength(150)]
        public string PositionName { get; set; }
        
        //
        public int Age { get; set; }
        public int YearExperience { get; set; }

        [Range(0,12,ErrorMessage ="ระบุได้ไม่เกิน12เดือน")]
        public int MonthExperience { get; set; }

        [Range(0,365,ErrorMessage ="ระบุได้ไม่เกิน365วัน")]
        public int DayExperience { get; set; }

        public int DriverExperience { get; set; }
        
        [StringLength(50)]
        public string   Telephone { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string Shift { get; set; }

        public CaseType CaseType { get; set; } //Enum

        public AccidentMode AccidentMode { get; set; }  //Enum

        public TransportBy TransportBy { get; set; }  //Enum

        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [StringLength(20)]
        public string PlateNumber { get; set; }

        public OtherBy OtherBy { get; set; }  //Enum

        public Rank Rank { get; set; } //Enum

        public int SolutionHour { get; set; }

        //2021-02-27
        public bool IsSub { get; set; }

    }
}
