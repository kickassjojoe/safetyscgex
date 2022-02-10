using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class CategoryResponse {
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Category {
        public int TruckInspectionCagegoryId { get; set; }
        public string Name { get; set; }
    }

    public class CategoryItem {
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item {
        public int TruckInspectionItemId { get; set; }
        public string Name { get; set; }
        public int TruckInspectionCategoryId { get; set; }
        public string TruckInspectionCategoryName { get; set; }
        public bool IsMust { get; set; }
        public bool IsFirstAndFifteenth { get; set; }
    }
}
