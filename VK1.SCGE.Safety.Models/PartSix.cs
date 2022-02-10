using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class PartSix : ModelBase {

        public int PartSixId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        [StringLength(3),ForeignKey(nameof(UnsafeItem))]
        public string UnsafeItemCode { get; set; }
        public virtual UnsafeItem UnsafeItem { get; set; }

        [StringLength(150)]
        public string UnsafeItemName{ get; set; }

        [StringLength(500)]
        public string Solution { get; set; }

        [StringLength(150)]
        public string ResponsePerson { get; set; }

        public DateTime DueDate { get; set; }
    }
}
