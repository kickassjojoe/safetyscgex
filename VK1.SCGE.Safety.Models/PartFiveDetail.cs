using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class PartFiveDetail: ModelBase {
        public int PartFiveDetailId { get; set; }

        [ForeignKey(nameof(PartFive))]
        public int PartFiveId { get; set; }
        public virtual PartFive PartFive { get; set; }

        [Required, StringLength(3)]
        [ForeignKey(nameof(UnsafeCategory))]
        public string UnsafeCategoryCode { get; set; }
        public virtual UnsafeCategory UnsafeCategory { get; set; }

        [Required, StringLength(3)]
        [ForeignKey(nameof(UnsafeItem))]
        public string UnsafeItemCode { get; set; }
        public virtual UnsafeItem UnsafeItem { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }
}
