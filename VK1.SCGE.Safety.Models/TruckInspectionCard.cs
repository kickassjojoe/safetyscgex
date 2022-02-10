using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
    public class TruckInspectionCard : ModelBase {
        public int TruckInspectionCardId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Employee))]
        [StringLength(11)]
        public string EmployeeCode { get; set; }
        public virtual Employee Employee { get; set; }

        public string EmployeeName { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? InspectionDate { get; set; }

        public int StartOdometer { get; set; }
        public int FinishedOdometer { get; set; }

        [JsonIgnore]
        public virtual ICollection<TruckInspectionCardDetail> TruckInspectionCardDetails { get; set; } = new HashSet<TruckInspectionCardDetail>();

        [ForeignKey(nameof(CardControl))]
        [StringLength(6)]
        public string CardControlCode { get; set; }
        public virtual CardControl CardControl { get; set; }

        [StringLength(15)]
        public string BranchCode { get; set; }
        [StringLength(200)]
        public string BranchName { get; set; }

        public int RegionId { get; set; }
        [StringLength(150)]
        public string RegionName { get; set; }

        public VehicleType VehicleType { get; set; }

        public virtual TruckInspectionCard NextCard { get; set; }

        public TruckInspectionCardDetail AddDetail(TruckInspectionCardDetail item) {
            try {
                TruckInspectionCardDetail detail = new TruckInspectionCardDetail();
                detail.TruckInspectionItemId = item.TruckInspectionItemId;
                detail.IsNormal = item.IsNormal;
                detail.PicturePath = item.PicturePath;
                detail.Remark = item.Remark;
                detail.CreatedBy = item.CreatedBy;
                detail.CreatedDate = item.CreatedDate;
                detail.TruckInspectionCard = this;

                TruckInspectionCardDetails.Add(detail);

                return detail;

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void AddOdometer(int value) {
            if (value <= StartOdometer) {
                throw new Exception("ไม่สามารถบันทึกเลขไมค์ขากลับน้อยกว่าเลขไมค์ขาไปได้");
            } else if (value > 999999) {
                throw new Exception("ไม่สามารถบันทึกเลขไมค์ขากลับมากกว่า 999999");
            }
            FinishedOdometer = value;
        }

        public int Distance => FinishedOdometer == 0 ? 0 : FinishedOdometer - StartOdometer;
    }
}
