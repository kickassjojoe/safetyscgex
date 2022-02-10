using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VK1.SCGE.Safety.Models {
   public class Carrier : ModelBase {
        public int CarrierId { get; set; }
        
        [Required,StringLength(150)]
        public string Name { get; set; }

    }
}
