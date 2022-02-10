using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Mvc.Models;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize(Roles = "Admin")]
    public class UserController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        // private readonly SelectListUtility selectListUtility;

        public UserController(UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager) {
            // SelectListUtility selectListUtility) {
            _userManager = userManager;
            _roleManager = roleManager;
            //  this.selectListUtility = selectListUtility;
        }

        //public async Task<IActionResult> Index(string sms) {
        //    TempData["Msg"] = sms;
        //    var arrUser = _userManager.Users.ToArray();
        //    List<UserListViewModel> viewModels = new List<UserListViewModel>();
        //    for (int i = 0; i < arrUser.Length; i++) {
        //        var user = arrUser[i];
        //        var rolename = await _userManager.GetRolesAsync(user);
        //        UserListViewModel model = new UserListViewModel {
        //            Id = user.Id,
        //            Name = user.Name,
        //            UserName = user.UserName,
        //            Email = user.Email,
        //            RoleName = rolename[0]
        //        };
        //        viewModels.Add(model);
        //    }

        //    ViewBag.User = viewModels;
        //    ViewBag.Roles = selectListUtility.SelectListRole;

        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model) {
            if (ModelState.IsValid) {
                try {
                    var user = new ApplicationUser {
                        Name = model.Name,
                        UserName = model.UserName,
                        Email = model.Email
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded) {
                        var c = result.Errors.Count();
                        string[] desc = new string[c];
                        int i = 0;
                        foreach (var item in result.Errors) {
                            desc[i] = item.Description;
                            i++;
                        }

                        TempData["ErrorDescription"] = desc;

                        return RedirectToAction(nameof(Index), new { sms = result.Errors.Select(s => s.Description.ToString()) });

                    }


                    ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (applicationRole == null) {
                        return RedirectToAction(nameof(Index), new { sms = "ApplicationRole not found." });
                    }

                    IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);

                    return RedirectToAction(nameof(Index), new { sms = "User is created Successfully." });

                } catch (Exception ex) {
                    string messsage = ex.InnerException != null ? ex.InnerException.InnerException.Message.ToString() : ex.Message.ToString();
                    return RedirectToAction(nameof(Index), new { sms = messsage });
                }
            } else {
                string messages = String.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToString());
                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }

        //public async Task<IActionResult> Edit(string id) {
        //    if (String.IsNullOrWhiteSpace(id)) {
        //        return RedirectToAction(nameof(Index), new { sms = "User not found." });
        //    }
        //    try {
        //        var user = await _userManager.FindByIdAsync(id);
        //        if (user == null) {
        //            return RedirectToAction(nameof(Index), new { sms = "User not found." });
        //        }

        //        var model = new EditUserViewModel {
        //            Name = user.Name,
        //            Email = user.Email,
        //            ApplicationRoleId = _roleManager.Roles.SingleOrDefault(r => r.Name == _userManager.GetRolesAsync(user).Result.SingleOrDefault()).Id
        //        };

        //        var arrUser = _userManager.Users.ToArray();
        //        List<UserListViewModel> viewModels = new List<UserListViewModel>();
        //        for (int i = 0; i < arrUser.Length; i++) {
        //            var _user = arrUser[i];
        //            var rolename = await _userManager.GetRolesAsync(_user);
        //            UserListViewModel _model = new UserListViewModel {
        //                Id = _user.Id,
        //                Name = _user.Name,
        //                UserName = _user.UserName,
        //                Email = _user.Email,
        //                RoleName = rolename[0]
        //            };
        //            viewModels.Add(_model);
        //        }

        //        ViewBag.User = viewModels;

        //        ViewBag.Roles = selectListUtility.SelectListRole;

        //        return View(nameof(Index), model);

        //    }
        //    catch (Exception ex) {
        //        string messages = ex.InnerException != null ? ex.InnerException.InnerException.Message.ToString() : ex.Message.ToString();
        //        return RedirectToAction(nameof(Index), new { sms = ex.Message.ToString() });
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(EditUserViewModel model, string id) {
        //    if (ModelState.IsValid) {
        //        try {
        //            ApplicationUser user = await _userManager.FindByIdAsync(id);
        //            if (user == null) return RedirectToAction("Index", new { sms = "User not found." });
        //            user.Name = model.Name;
        //            user.Email = model.Email;

        //            string existingRole = _userManager.GetRolesAsync(user).Result.SingleOrDefault();
        //            string existingRoleId = _roleManager.Roles.SingleOrDefault(r => r.Name == existingRole).Id;

        //            IdentityResult result = await _userManager.UpdateAsync(user);

        //            if (!result.Succeeded) return RedirectToAction(nameof(Index), new { sms = "Update not complete" });

        //            if (existingRoleId != model.ApplicationRoleId) {

        //                IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);

        //                if (!roleResult.Succeeded) return RedirectToAction(nameof(Index), new { sms = "Remove ApplicationRole not complete." });

        //                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);

        //                if (applicationRole == null) return RedirectToAction(nameof(Index), new { sms = "ApplicationRole not found." });

        //                IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);

        //                if (!newRoleResult.Succeeded) return RedirectToAction(nameof(Index), new { sms = "New Role not found." });

        //                return RedirectToAction(nameof(Index), new { sms = "User is edited Successfully." });
        //            }
        //        }
        //        catch (DbUpdateConcurrencyException) {
        //            if (!UserExist(model.Id)) {
        //                return RedirectToAction(nameof(Index), new { sms = "User not found." });
        //            }
        //        }
        //    }
        //    else {
        //        string messages = String.Join("; ", ModelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage.ToString()));
        //        return RedirectToAction(nameof(Index), new { sms = messages });
        //    }

        //    return RedirectToAction(nameof(Index), new { sms = "User is edited Successfully." });

        //}

        //private bool UserExist(string id) {
        //    return _userManager.Users.Select(s => s.Id == id).Any();
        //}

        //public async Task<IActionResult> Delete(string id) {
        //    if (String.IsNullOrWhiteSpace(id)) {
        //        return RedirectToAction(nameof(Index), new { sms = "User not found." });
        //    }
        //    ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
        //    if (applicationUser == null) {
        //        return RedirectToAction(nameof(Index), new { sms = "User not found." });
        //    }

        //    IdentityResult result = await _userManager.DeleteAsync(applicationUser);
        //    if (!result.Succeeded) return RedirectToAction(nameof(Index), new { sms = "Delete not complete" });

        //    return RedirectToAction(nameof(Index));
        //}
    }
}