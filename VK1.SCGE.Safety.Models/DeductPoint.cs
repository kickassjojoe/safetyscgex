using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class DeductPoint {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeductPointId { get; set; }

        [StringLength(2)]
        public string DeductCode { get; set; }

        [StringLength(150)]
        public string DeductDescription { get; set; }

        [StringLength(150)]
        public string Warning { get; set; }

        public int Point { get; set; }

    }
}
