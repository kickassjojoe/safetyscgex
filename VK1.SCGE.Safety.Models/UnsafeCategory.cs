using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class UnsafeCategory : ModelBase {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required, StringLength(3)]
        public string UnsafeCategoryCode { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public UnsafeType UnsafeType { get; set; }
    }
}
