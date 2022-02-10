using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class CorrectiveActionRequestStatus {
        [Key,StringLength(3)]
        [Required]
        public string CARStatusCode { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

    }
}
