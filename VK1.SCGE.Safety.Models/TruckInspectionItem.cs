using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
    public class TruckInspectionItem : ModelBase {
        public int TruckInspectionItemId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [ForeignKey(nameof(TruckInspectionCategory))]
        public int TruckInspectionCategoryId { get; set; }

        public bool IsMust { get; set; }

        public bool IsFirstAndFifteenth { get; set; }

        [JsonIgnore]
        public virtual TruckInspectionCategory TruckInspectionCategory { get; set; }

       // [JsonIgnore]
       // public virtual ICollection<TruckInspectionCard> TruckInspectionCards { get; set; } = new HashSet<TruckInspectionCard>();

    }
}
