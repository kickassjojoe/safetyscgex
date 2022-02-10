using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class InvestigateStatus : ModelBase{
        [Key,StringLength(3)]
        [Required]
        public string InvestigateStatusCode { get; set; }

        [StringLength(150)]
        [Required]
        public string Name { get; set; }
    }
}
