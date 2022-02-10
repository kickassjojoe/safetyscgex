using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class UnsafeCategoryDto {
        public string Code { get; set; }
        public string Name { get; set; }
        public UnsafeType UnsafeType { get; set; }
    }
}
