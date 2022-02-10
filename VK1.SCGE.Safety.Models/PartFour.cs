using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.Text;

namespace VK1.SCGE.Safety.Models {
   public class PartFour : ModelBase {
        public int PartFourId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        [ForeignKey(nameof(IncidentTruck))]
        public int IncidentTruckId { get; set; }
        public virtual IncidentTruck IncidentTruck { get; set; }   //รถยนต์

        [StringLength(500)]
        public string IncidentTruckDescription { get; set; }

        [ForeignKey(nameof(IncidentTruckPositon))]
        public int IncidentTruckPositonId { get; set; }
        public virtual IncidentTruckPositon IncidentTruckPositon { get; set; } //ตำแหน่งรถที่หยุดหลังเกิดเหตุ

        [StringLength(500)]
        public string IncidentTruckPositionDescription { get; set; }

        [ForeignKey(nameof(IncidentArea))]
        public int IncidentAreaId { get; set; }
        public virtual IncidentArea IncidentArea { get; set; } // ลักษณะบริเวณเกิดเหตุ

        [StringLength(500)]
        public string IncidentAreaDescription { get; set; }

        [ForeignKey(nameof(IncidentRoad))]
        public int? IncidentRoadId { get; set; }
        public virtual IncidentRoad IncidentRoad { get; set; }  //ลักษณะบริเวณเกิดเหตุ(ทางถนน)

        [StringLength(500)]
        public string IncidentRoadDescription { get; set; }

        [ForeignKey(nameof(AreaCondition))]
        public int AreaConditionId { get; set; }
        public virtual AreaCondition AreaCondition { get; set; } //สภาพพื้นที่

        [StringLength(500)]
        public string AreaConditionDescription { get; set; }

        [ForeignKey(nameof(Weather))]
        public int WeatherId { get; set; }
        public virtual Weather Weather { get; set; }  //สภาพอากาศ

        [StringLength(500)]
        public string WeatherDescription { get; set; }

        [ForeignKey(nameof(Traffic))]
        public int TrafficId { get; set; }
        public virtual Traffic Traffic { get; set; }  //การจราจร

        [ForeignKey(nameof(IncidentDepot))]
        public int? IncidentDepotId { get; set; }
        public virtual IncidentDepot IncidentDepot { get; set; }  // ลักษณะบริเวณเกิดเหตุ(ในคลัง/สาขา)

        public int? FallFromHeight { get; set; }

        [StringLength(500)]
        public string IncidentDepotDescription { get; set; }

    }
}

