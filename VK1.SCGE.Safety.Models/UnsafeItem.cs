using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class UnsafeItem : ModelBase {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required,StringLength(3)]
        public string UnsafeItemCode { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(3)]
        [ForeignKey(nameof(UnsafeCategory))]
        public string UnsafeCategoryCode { get; set; }
        public virtual UnsafeCategory UnsafeCategory { get; set; }

        public int DeductPoint { get; set; }

    }
}
