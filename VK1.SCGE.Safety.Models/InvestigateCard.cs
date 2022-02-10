using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class InvestigateCard : ModelBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid InvestigateCardId { get; set; }

        public virtual PartOne PartOne { get; set; }
        public virtual PartTwo PartTwo { get; set; }
        public virtual PartThree PartThree { get; set; }
        public virtual PartFour PartFour { get; set; }
        public virtual PartFive PartFive { get; set; }
        public virtual ICollection<PartSix> PartSixes { get; set; } = new HashSet<PartSix>();

        [ForeignKey(nameof(InvestigateStatus))]
        [StringLength(3)]
        public string InvestigateStatusCode { get; set; } = "100";
        public virtual InvestigateStatus InvestigateStatus { get; set; }

        //2021-02-24
        public bool IsApprove { get; set; }
        [StringLength(150)]
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        // public virtual ICollection<PenaltyNotice> PenaltyNotices { get; set; } = new HashSet<PenaltyNotice>();

        public void SetApprove(string username) {
            IsApprove = true;
            InvestigateStatusCode = "300";
            ApprovedBy = username;
            ApprovedDate = DateTime.Now;
        }

    }
}
