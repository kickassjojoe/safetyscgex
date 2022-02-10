using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class PartFive : ModelBase {
        public int PartFiveId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        public virtual ICollection<PartFiveDetail> PartFiveDetails { get; set; } = new HashSet<PartFiveDetail>();

        [StringLength(500)]
        public string Remark { get; set; }

        public PartFiveDetail AddDetail(PartFiveDetail item,string username) {
            PartFiveDetail pf = new PartFiveDetail();
            pf.UnsafeCategoryCode = item.UnsafeCategoryCode;
            pf.UnsafeItemCode = item.UnsafeItemCode;
            pf.Description = item.Description;
            pf.PartFive = this;
            pf.CreatedBy = username;

            PartFiveDetails.Add(pf);

            return pf;
        }

        public void RemoveDetail(PartFiveDetail item) {
            PartFiveDetails.Remove(item);
        }
    }
}
