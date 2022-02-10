using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Services;
using VK1.SCGE.Safety.Mvc.Dtos;

namespace VK1.SCGE.Safety.Mvc.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase {
        private readonly App app;

        public CategoryApiController(App app) {
            this.app = app;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories() {
            var categories = await app.TruckInspectionCategories.AllAsync();
            if (categories == null) {
                return NotFound();
            }

            //            var result = new List<CategoryResponse>();

            var result = new CategoryResponse();
            result.StatusCode = "200";
            result.StatusName = "success";
            List<Category> items = new List<Category>();
            foreach (var item in categories) {
                Category c = new Category();
                c.TruckInspectionCagegoryId = item.TruckInspectionCategoryId;
                c.Name = item.Name;

                items.Add(c);
            }

            result.Categories = items;

            return Ok(result);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(int id) {
            var category = await app.TruckInspectionCategories.FindAsync(id);
            if (category == null) {
                return NotFound();
            }

            CategoryItem result = new CategoryItem();
            result.StatusCode = "200";
            result.StatusName = "success";
            List<Item> listItem = new List<Item>();
            foreach (var i in category.TruckInspectionItems) {
                Item objItem = new Item();
                objItem.TruckInspectionCategoryId = i.TruckInspectionCategoryId;
                objItem.TruckInspectionCategoryName = i.TruckInspectionCategory.Name;
                objItem.TruckInspectionItemId = i.TruckInspectionItemId;
                objItem.Name = i.Name;
                objItem.IsMust = i.IsMust;
                objItem.IsFirstAndFifteenth = i.IsFirstAndFifteenth;

                listItem.Add(objItem);
            }

            result.Items = listItem;

            return Ok(result);
        }
    }
}
