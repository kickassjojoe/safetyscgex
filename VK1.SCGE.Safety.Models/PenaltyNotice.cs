using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class PenaltyNotice : ModelBase {
        //backing field
        private decimal _deductMoneyAccident;

        [Key, StringLength(11), Required]
        public string PenaltyNoticeCode { get; set; }

        [StringLength(11)]
        public string EmployeeCode { get; set; }

        [StringLength(150)]
        public string EmployeeName { get; set; }

        [StringLength(15)]
        public string BranchCode { get; set; }

        [StringLength(150)]
        public string BranchName { get; set; }

        [StringLength(200)]
        public string IncidentDescription { get; set; }

        public DateTime CaseDate { get; set; }

        [StringLength(15)]
        public string CaseCount { get; set; }

        [StringLength(250)]
        public string DeductDescription { get; set; }

        [StringLength(250)]
        public string TruckDamageDescription { get; set; }

        [StringLength(250)]
        public string Warning { get; set; }

        public int DeductPointAccident { get; set; }

        public decimal DeductMoneyAccident {
            get => _deductMoneyAccident;
            private set { }
        }

        public int DeductPointUnsafe { get; set; }
        public decimal DeductMoneyUnsafe { get; set; }

        //2021-02-12
        [ForeignKey(nameof(InvestigateCard))]
        public Guid? InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        public virtual ICollection<PenaltyNoticeDetail> Items { get; set; } = new HashSet<PenaltyNoticeDetail>();

        public int TotalDeductPoint {
            get {
                return DeductPointUnsafe + DeductPointAccident;
            }
        }

        public void SetDeductAccident(int time, bool isSub) {
            if (isSub==true) {
                _deductMoneyAccident = 0;
            } else {
                if (time != 0) {
                    if (time == 1) {
                        _deductMoneyAccident = 500;
                    } else if (time == 2) {
                        _deductMoneyAccident = 1000;
                    } else { _deductMoneyAccident = 1500; }
                }
            }
        }
    }
}
