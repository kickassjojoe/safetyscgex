using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
    public class Branch : ModelBase {
        [Key, Required, StringLength(15)]
        public string BranchCode { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string BranchManager { get; set; }

        [EmailAddress,StringLength(50)]
        public string Email { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }


        //[JsonIgnore]
        //public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
