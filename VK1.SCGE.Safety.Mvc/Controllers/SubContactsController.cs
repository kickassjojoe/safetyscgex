using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Mvc.Models;
using VK1.SCGE.Safety.Mvc.Models.ManageViewModels;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class SubContactsController : Controller {
        private readonly App app;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public SubContactsController(App app,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<ApplicationRole> roleManager,
                                    SignInManager<ApplicationUser> signInManager) {
            this.app = app;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<List<SubContact>> Contacts() => (await app.SubContacts.AllAsync()).ToList();
        public async Task<List<Branch>> Branches() => (await app.Branches.AllAsync()).ToList();
        public async Task<List<Region>> Regions() => (await app.Regions.AllAsync()).ToList();

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Master";

            ViewBag.Model = await Contacts();

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register(string sms) {
            TempData["Msg"] = sms;

            ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, x.Name }), "Id", "Name");
            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(SubContact item) {
            try {
                if (ModelState.IsValid) {
                    await app.SubContacts.UpdateAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(Register), new { sms = "Successfully" });
                } else {
                    string message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToString();

                    return RedirectToAction(nameof(Register), new { sms = message });
                }

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Register), new { sms = message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id) {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                try {
                    var sub = await app.SubContacts.FindAsync(id);

                    var role = await roleManager.FindByNameAsync("Sub contact");
                    UserViewModel usermodel = new UserViewModel {
                        Name = sub.Name,
                        UserName = sub.Username,
                        Password = "Initial_1234",
                        ConfirmPassword = "Initial_1234",
                        Email = "sub@scgexpress.co.th",
                        ApplicationRoleId = role.Id
                    };

                    var isCreateUser = await CreateUser(usermodel);
                    if (!isCreateUser) {
                        return Json(new {
                            Error = "Created user failed."
                        });
                    }

                    //add sub contact vehicle
                    Vehicle vehicle = new Vehicle();
                    vehicle.PlateNumber = sub.PlateNumber;
                    vehicle.BranchCode = sub.BranchCode;
                    vehicle.Brand = sub.Brand;
                    vehicle.GpsProvider = sub.GpsProvider;
                    vehicle.RegionId = sub.RegionId;
                    vehicle.RegionName = sub.Region.Name;
                    vehicle.IsSubContact = true;
                    vehicle.SubContactId = sub.SubContactId;
                    await app.Vehicles.AddAsync(vehicle);
                    await app.SaveChangesAsync();

                    sub.IsApproved = true;
                    sub.VehicleId = vehicle.Id;
                    await app.SubContacts.UpdateAsync(sub);

                    await app.SaveChangesAsync();

                    scope.Complete();

                    return Json(new { Error = "" });

                } catch (Exception ex) {
                    string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return Json(new { Error = message });
                }
            }
        }

        private async Task<bool> CreateUser(UserViewModel model) {
            if (ModelState.IsValid) {
                try {
                    var user = new ApplicationUser {
                        Name = model.Name,
                        UserName = model.UserName,
                        Email = model.Email
                    };

                    IdentityResult result = await userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded) {
                        var c = result.Errors.Count();
                        string[] desc = new string[c];
                        int i = 0;
                        foreach (var item in result.Errors) {
                            desc[i] = item.Description;
                            i++;
                        }
                        TempData["ErrorDescription"] = desc;
                        throw new Exception($"{result.Errors.Select(s => s.Description.ToString())}");
                    }

                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole == null) {
                        throw new Exception($"ApplicationRole not found.");
                    }

                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);

                    return true;

                } catch (Exception ex) {
                    string messsage = ex.InnerException != null ? ex.InnerException.InnerException.Message.ToString() : ex.Message.ToString();
                    throw new Exception(messsage);
                }

            } else {
                throw new Exception($"{ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)}");
            }
        }

        public async Task<IActionResult> GetAll() {
            ViewBag.Model = await Contacts();
            return PartialView("_Table");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                try {
                    var sub = await app.SubContacts.FindAsync(id);
                    if (sub == null) return Json(new { Error = "Data not found" });

                    await DeleteAspNetUser(sub.Username);

                    if (sub.IsApproved) {
                       // sub.Vehicle.IsDeleted = true;
                        sub.IsApproved = false;
                        sub.VehicleId = 0;
                    }
                    sub.IsDeleted = true;

                    await app.SubContacts.UpdateAsync(sub);

                    await app.SaveChangesAsync();

                    scope.Complete();

                    return Json(new { Error = "" });

                } catch (Exception ex) {
                    return Json(new { Error = ex.InnerException != null ? ex.InnerException.Message : ex.Message });
                }
            }
        }

        public async Task DeleteAspNetUser(string username) {
            try {
                ApplicationUser applicationUser = await userManager.FindByNameAsync(username);
                if (applicationUser != null) {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (!result.Succeeded)
                        throw new Exception("Cannot delete aspnet user");
                }

            } catch (Exception ex) {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public IActionResult ChangePassword(string sms) {
            TempData["Msg"] = sms;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null) {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded) {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            string message = "Your password has been changed. สำเร็จ";

            return RedirectToAction(nameof(ChangePassword), new { sms = message });
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}
