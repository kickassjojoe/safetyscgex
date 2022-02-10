using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VK1.SCGE.Safety.Models {
    public class PartThree {
        public int PartThreeId { get; set; }

        [ForeignKey(nameof(InvestigateCard))]
        public Guid InvestigateCardId { get; set; }
        public virtual InvestigateCard InvestigateCard { get; set; }

        [StringLength(500)]
        public string BeforeIncidentDescription { get; set; }

        [StringLength(500)]
        public string IncidentDescription { get; set; }

        [StringLength(500)]
        public string AfterIncidentDescription { get; set; }

        [StringLength(150)]
        public string ImageBeforeIncidenName { get; set; }

        [NotMapped]
        public IFormFile ImageBeforeIncidenFile { get; set; }

        [StringLength(150)]
        public string ImageIncidentName { get; set; }

        [NotMapped]
        public IFormFile ImageIncidenFile { get; set; }

        [StringLength(150)]
        public string ImageAfterIncidentName { get; set; }

        [NotMapped]
        public IFormFile ImageAfterIncidenFile { get; set; }

        [StringLength(150)]
        public string ImageIncidentAreaName { get; set; }

        [NotMapped]
        public IFormFile ImageIncidentAreaFile { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }
}
