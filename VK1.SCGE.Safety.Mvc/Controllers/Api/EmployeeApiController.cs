using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase {
        private readonly App app;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeeApiController(App app, UserManager<ApplicationUser> userManager) {
            this.app = app;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeCode() {
            //if (GlobalData.LoginUserName == null) {
            //    return NotFound("not found user login");
            //}
            var isAuthen = User.Identity.IsAuthenticated;
            if (!User.Identity.IsAuthenticated) {
                return NotFound("not found user login");
            } else {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                var compare = role.CompareTo("Sub contact");
                if (compare == 0) {
                    var result = await GetEmployeeResponseByName(User.Identity.Name);
                    return Ok(result);
                }
            }
            var loginName = User.Identity.Name;
            string id = $"{loginName.Substring(0, 4)}-{loginName.Substring(4, 6)}";
            var employee = await GetEmployeeResponseById(id);
            if (employee == null) {
                return NotFound();
            }
            
            return Ok(employee);
        }

        public async Task<EmployeeResponse> GetEmployeeResponseById(string id) {
            var employee = await app.Employees.FindAsync(id);
            var result = new EmployeeResponse {
                EmployeeCode = employee.EmployeeCode,
                NameTH = employee.NameTH,
                NameEN = employee.NameEN,
                Position = employee.Position,
                BusinessUnitLevel2 = employee.BusinessUnitLevel2,
                BusinessUnitLevel3 = employee.BusinessUnitLevel3,
                BusinessUnitLevel4 = employee.BusinessUnitLevel4,
                BusinessUnitLevel5 = employee.BusinessUnitLevel5,
                BusinessUnitLevel6 = employee.BusinessUnitLevel6,
                Division = employee.Division,
                Branch = employee.Branch,
                BranchCode = employee.BranchCode,
                BranchName = employee.BranchName,
                Email = employee.Email,
                SupervisorCode = employee.SupervisorCode,
                SupervisorEmail = employee.SupervisorEmail,
                SupervisorPosition = employee.SupervisorPosition
            };

            return result;

        }

        public async Task<EmployeeResponse> GetEmployeeResponseByName(string name) {
            var employee = (await app.Employees.QueryAsyncAsNoTracking(x=>x.NameTH==name)).FirstOrDefault();
            var result = new EmployeeResponse {
                EmployeeCode = employee.EmployeeCode,
                NameTH = employee.NameTH,
                NameEN = employee.NameEN,
                Position = employee.Position,
                BusinessUnitLevel2 = employee.BusinessUnitLevel2,
                BusinessUnitLevel3 = employee.BusinessUnitLevel3,
                BusinessUnitLevel4 = employee.BusinessUnitLevel4,
                BusinessUnitLevel5 = employee.BusinessUnitLevel5,
                BusinessUnitLevel6 = employee.BusinessUnitLevel6,
                Division = employee.Division,
                Branch = employee.Branch,
                BranchCode = employee.BranchCode,
                BranchName = employee.BranchName,
                Email = employee.Email,
                SupervisorCode = employee.SupervisorCode,
                SupervisorEmail = employee.SupervisorEmail,
                SupervisorPosition = employee.SupervisorPosition
            };

            return result;

        }
    }
}
