using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class SubContactDtos {
        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }

        [Required]
        public string BranchCode { get; set; }

        [Required, StringLength(100)]
        public string GpsProvider { get; set; }

        public VehicleType VehicleType { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required, StringLength(15)]
        public string RegionName { get; set; }

        [Required,StringLength(100)]
        public string Brand { get; set; }

    }
}
