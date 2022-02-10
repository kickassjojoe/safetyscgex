using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
    public class Vehicle : ModelBase {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Branch)), StringLength(15)]
        public string BranchCode { get; set; }

        [JsonIgnore]
        public virtual Branch Branch { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }

        [StringLength(100)]
        public string GpsProvider { get; set; }

        public VehicleType VehicleType { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        [Required, StringLength(15)]
        public string RegionName { get; set; }

        public bool IsSubContact { get; set; }  // yes if there is sub contact

        [ForeignKey(nameof(SubContact))]
        public int? SubContactId { get; set; }
        public virtual SubContact SubContact { get; set; }

        public bool IsUse { get; set; }

        [JsonIgnore]
        public virtual ICollection<TruckInspectionCard> TruckInspectionCards { get; set; } = new HashSet<TruckInspectionCard>();
    }
}

