using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class CorrectiveActionRequest {
        [Required]
        [Key, StringLength(20)]
        public string CARCode { get; set; }

        public DateTime Created { get; set; }

        [StringLength(150)]
        public string CreatedBy { get; set; }

        [StringLength(200)]
        public string ViewerName { get; set; }

        [StringLength(200)]
        public string ViewerEmail { get; set; }

        [StringLength(200)]
        public string ViewerDepartment { get; set; }

        [StringLength(200)]
        public string ViewerDivision { get; set; }

        public VehicleType VehicleType { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }
        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [StringLength(3)]
        [ForeignKey(nameof(CorrectiveActionRequestStatus))]
        public string CARStatusCode { get; set; }
        public virtual CorrectiveActionRequestStatus CorrectiveActionRequestStatus { get; set; }

        [StringLength(200)]
        public string CARStatusName { get; set; }

        [ForeignKey(nameof(Branch)), StringLength(15)]
        public string BranchCode { get; set; }
        public virtual Branch Branch { get; set; }

        [StringLength(200)]
        public string BranchName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApprovedDate { get; set; }

        [StringLength(200)]
        public string ApprovedBy { get; set; }

        [StringLength(200)]
        public string PdfPath { get; set; }

        public virtual ICollection<CorrectiveActionRequestItem> Items { get; set; } = new HashSet<CorrectiveActionRequestItem>();

        public void Approve(string username,int[] chk) {
            var items = Items.Where(x=>chk.Contains(x.CARItemId)).ToList();
            items.ForEach(x => {
                x.IsFixed = true;
                x.FixedDate = DateTime.Now;
                x.FixedBy = username;
                x.TruckInspectionCardDetail.IsFixed = true;
                x.TruckInspectionCardDetail.Modified = DateTime.Now;
                x.TruckInspectionCardDetail.ModifiedBy = username;
            });

            var isAllFixed = Items.All(x => x.IsFixed == true);
            if (isAllFixed) {
                CARStatusCode = "300";
                CARStatusName = "FullApproved";
                ApprovedDate = DateTime.Now;
                ApprovedBy = username;
                return;
            }

            var isAnyFixed = Items.Any(x => x.IsFixed == true);
            if (isAnyFixed) {
                CARStatusCode = "200";
                CARStatusName = "PartialApproved";
                ApprovedDate = DateTime.Now;
                ApprovedBy = username;
                return;
            }
            return;
        }
    }
}
