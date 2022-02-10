using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class TruckInspectionCardDetail : ModelBase {
        public int Id { get; set; }
            
        [ForeignKey(nameof(TruckInspectionCard))]
        public int? TruckInspectionCardId { get; set; }
        public virtual TruckInspectionCard TruckInspectionCard { get; set; }

        [ForeignKey(nameof(TruckInspectionItem))]
        public int TruckInspectionItemId { get; set; }
        public virtual TruckInspectionItem TruckInspectionItem { get; set; }

        public bool? IsNormal { get; set; } = null;

        [StringLength(100)]
        public string PicturePath { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public bool IsFixed { get; set; }
    }
}
