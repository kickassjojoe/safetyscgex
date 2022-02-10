using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class PenaltyNoticeDetail {
        public int PenaltyNoticeDetailId { get; set; }
        
        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey(nameof(PenaltyNotice))]
        [StringLength(11)]
        public string PenaltyNoticeCode { get; set; }
        public virtual PenaltyNotice PenaltyNotice { get; set; }
    }
}
