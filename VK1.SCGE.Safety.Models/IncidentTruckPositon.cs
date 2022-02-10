using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class IncidentTruckPositon : ModelBase {
        public int IncidentTruckPositonId { get; set; }
        
        [StringLength(150)]
        public string Name { get; set; }
    }
}
