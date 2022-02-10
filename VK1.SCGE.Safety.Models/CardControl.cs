using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class CardControl {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(6)]
        public string Code { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public virtual ICollection<TruckInspectionCard> Cards { get; set; } = new HashSet<TruckInspectionCard>();

        public TruckInspectionCard AddCard(TruckInspectionCard item, List<TruckInspectionCardDetail> details) {
            var c = new TruckInspectionCard() {
                TruckInspectionCardId = item.TruckInspectionCardId,
                EmployeeCode = item.EmployeeCode,
                EmployeeName = item.EmployeeName,
                VehicleId = item.VehicleId,
                PlateNumber = item.PlateNumber,
                InspectionDate = item.InspectionDate,
                StartOdometer = item.StartOdometer,
                FinishedOdometer = item.FinishedOdometer,
                BranchCode=item.BranchCode,
                BranchName=item.BranchName,
                RegionId=item.RegionId,
                RegionName=item.RegionName,
                VehicleType=item.VehicleType
            };

            foreach (var d in details) {
                c.AddDetail(d);
            }

            var last = Cards.LastOrDefault();
            if (last != null) {
                last.NextCard = c;
            }

            Cards.Add(c);

            return c;
        }

        public int? FirstOdometerOfMonth(string branch, int vehicleId) => Cards.Where(x =>
                     x.Vehicle.BranchCode == branch
                    && x.VehicleId == vehicleId).FirstOrDefault().StartOdometer;

        public int? LastOdometerOfMonth(string branch, int vehicleId) => Cards.Where(x =>
                       x.Vehicle.BranchCode == branch
                      && x.VehicleId == vehicleId).LastOrDefault().FinishedOdometer;

    }
}
