using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class Traffic : ModelBase {
        public int TrafficId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

    }
}
