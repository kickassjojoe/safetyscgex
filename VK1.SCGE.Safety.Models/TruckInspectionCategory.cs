using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace VK1.SCGE.Safety.Models {
    public class TruckInspectionCategory : ModelBase {
        public int TruckInspectionCategoryId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<TruckInspectionItem> TruckInspectionItems { get; set; } = new HashSet<TruckInspectionItem>();

        [JsonIgnore]
        public virtual ICollection<TruckInspectionCard> TruckInspectionCards { get; set; } = new HashSet<TruckInspectionCard>();

    }
}
