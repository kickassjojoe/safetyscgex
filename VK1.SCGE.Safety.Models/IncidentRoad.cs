using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class IncidentRoad : ModelBase {
        public int IncidentRoadId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

    }
}
