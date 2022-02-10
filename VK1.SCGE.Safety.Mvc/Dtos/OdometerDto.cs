using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class OdometerDto {
        public int TruckInspectionCardId { get; set; }

        [Required]
        public int Odometer { get; set; }
    }
}
