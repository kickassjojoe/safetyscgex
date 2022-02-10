using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
   public class CorrectiveActionRequestItem {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CARItemId { get; set; }

        [Required,StringLength(20)]
        [ForeignKey(nameof(CorrectiveActionRequest))]
        public string CARCode { get; set; }
        public virtual CorrectiveActionRequest CorrectiveActionRequest { get; set; }

        [ForeignKey(nameof(TruckInspectionCardDetail))]
        public int? TruckInspectionCardDetailId { get; set; }

        [JsonIgnore]
        public virtual TruckInspectionCardDetail TruckInspectionCardDetail { get; set; }

        [ForeignKey(nameof(TruckInspectionCategory))]
        public int? TruckInspectionCategoryId { get; set; }
        public virtual TruckInspectionCategory TruckInspectionCategory { get; set; }

        [StringLength(200)]
        public string TruckInspectionCategoryName { get; set; }

        [ForeignKey(nameof(TruckInspectionItem))]
        public int? TruckInspectionItemId { get; set; }
        public virtual TruckInspectionItem TruckInspectionItem { get; set; }

        [StringLength(200)]
        public string TruckInspectionItemName { get; set; }

        public bool IsFixed { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime? IssuedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FixedDate { get; set; }

        [StringLength(200)]
        public string FixedBy { get; set; }

    }
}
