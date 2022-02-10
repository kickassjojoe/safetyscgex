using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class Weather : ModelBase {
        public int WeatherId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }
    }
}
