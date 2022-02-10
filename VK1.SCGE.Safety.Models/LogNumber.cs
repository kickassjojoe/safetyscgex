using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class LogNumber {
        public LogNumber() {
            //
        }

        public LogNumber(string prefix, string desc, int maxNumber) {
            Prefix = prefix;
            Description = desc;
            MaxNumber = maxNumber;
        }

        [Key]
        [Required, StringLength(6)]
        public string Prefix { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public int MaxNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; } = DateTime.Now.Date;

        public int GetMax(string prefix) => Prefix == prefix ? MaxNumber : 0;

     }
}
