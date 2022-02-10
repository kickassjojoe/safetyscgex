using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Mvc.Models;
using System.Xml;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class ApplicationRoleController : Controller {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _application;

        public ApplicationRoleController(RoleManager<ApplicationRole> roleManager,
                                         ApplicationDbContext application) {
            _roleManager = roleManager;
            _application = application;
        }

        public List<ApplicationRoleListViewModel> All() => _roleManager.Roles.Select(r => new ApplicationRoleListViewModel {
            RoleName = r.Name,
            Id = r.Id,
            Description = r.Description,
            NumberOfUsers = _application.UserRoles.Count(c => c.RoleId == r.Id)
        }).ToList();


        public IActionResult Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.Role = All();
            return View();
        }

        public IActionResult GetAll() {
            ViewBag.Role = All();
            return PartialView("_Table");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationRoleViewModel model) {
            if (ModelState.IsValid) {
                ApplicationRole applicationRole = new ApplicationRole {
                    CreatedDate = DateTime.Now,
                    Name = model.RoleName,
                    Description = model.Description,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };

                IdentityResult result = await _roleManager.CreateAsync(applicationRole);

                if (result.Succeeded) {
                    // return RedirectToAction(nameof(Index), new { sms = "Role is created Successfully" });
                    var response = new {
                        Error = ""
                    };
                    return Json(response);
                } else {
                    //  return RedirectToAction(nameof(Index), new { sms = result.Errors.Select(s => s.Description.ToString()) });
                    var message = result.Errors.Select(x => x.Description.ToString()); //result.Errors.Select(s => s.Description.ToString());
                    var response = new {
                        Error = message.FirstOrDefault().ToString()
                    };
                    return Json(response);
                }
            } else {
                var response = new {
                    Error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                };
                return Json(response);
            }
        }

        public async Task<IActionResult> Edit(string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                return RedirectToAction(nameof(Index), new { sms = "Role not found." });
            }

            ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id);
            if (_application == null) {
                return RedirectToAction(nameof(Index), new { sms = "Role not found." });
            }

            ViewBag.Role = _roleManager.Roles.Select(r => new ApplicationRoleListViewModel {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
                NumberOfUsers = _application.UserRoles.Count(c => c.RoleId == r.Id)
            }).ToList();

            return View(nameof(Index), applicationRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationRole applicationRole) {
            if (applicationRole.Id != id) {
                return RedirectToAction(nameof(Index), new { sms = "Role not found." });
            }
            try {
                if (ModelState.IsValid) {
                    var role = await _roleManager.FindByIdAsync(id);

                    role.Name = applicationRole.Name;
                    role.Description = applicationRole.Description;
                    role.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                    IdentityResult result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded) {
                        return RedirectToAction(nameof(Index), new { sms = "Role is edited Successfully." });
                    } else {
                        return RedirectToAction(nameof(Index), new { sms = result.Errors.Select(s => s.Description.ToString()) });
                    }
                }
            } catch (DbUpdateConcurrencyException) {
                if (!ApplicationRoleExists(id)) {
                    return RedirectToAction(nameof(Index), new { sms = "Role not found." });
                }
            }
            return View();
        }

        private bool ApplicationRoleExists(string id) {
            return _roleManager.Roles.Any(r => r.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            if (String.IsNullOrWhiteSpace(id)) {
                return RedirectToAction(nameof(Index), new { sms = "Role not found." });
            }

            ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id);
            if (applicationRole == null) {
                // return RedirectToAction(nameof(Index), new { sms = "Role not found." });
                return Json(new {
                    Error = "Role not found."
                });
            }

            IdentityResult result = _roleManager.DeleteAsync(applicationRole).Result;

            if (result.Succeeded) {
                // return RedirectToAction(nameof(Index), new { sms = "Role is deleted Successfully." });
                return Json(new {
                    Error = ""
                });
            } else {
                // return RedirectToAction(nameof(Index), new { sms = result.Errors.Select(s => s.Description.ToString()) });
                return Json(new {
                    Error = result.Errors.Select(s => s.Description.ToString())
                });
            }

        }
    }
}