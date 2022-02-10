using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class Region : ModelBase {
        public int RegionId { get; set; }

        [Required,StringLength(150)]
        public string Name { get; set; }

      //  public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
