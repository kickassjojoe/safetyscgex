using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class CARUploadFileViewModel {
        public string CARCode { get; set; }
        public IFormFile PdfFile { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string BranchCode { get; set; }
        public string Status { get; set; }
    }
}
