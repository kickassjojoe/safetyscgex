using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class SubContact : ModelBase {
        public int SubContactId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Branch)), StringLength(15)]
        public string BranchCode { get; set; }

        public virtual Branch Branch { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }

        [Required, StringLength(100)]
        public string GpsProvider { get; set; }

        public VehicleType VehicleType { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public bool IsApproved { get; set; }

        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
