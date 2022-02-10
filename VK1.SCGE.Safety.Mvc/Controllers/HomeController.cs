using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Mvc.Models;
using VK1.SCGE.Safety.Services;


namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly OnebookQuery onebookQuery;
        private readonly App app;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Util util;
        private readonly ILog log;

        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string Welcome { get; set; }

        public HomeController(ILogger<HomeController> logger,
                                IWebHostEnvironment webHostEnvironment,
                                OnebookQuery onebookQuery,
                                App app,
                                RoleManager<ApplicationRole> roleManager,
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                Util util,
                                ILog log
                                ) {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            this.util = util;
            this.log = log;
            this.webHostEnvironment = webHostEnvironment;
            this.onebookQuery = onebookQuery;
            this.app = app;
        }

        public IActionResult Index(string sms) {
            ViewBag.ActiveMenu = "Home";
            TempData["Msg"] = sms;
            return View();
        }
        [Authorize]
        public IActionResult Privacy() {
            ViewBag.ActiveMenu = "Privacy";
            return View();
        }

        public IActionResult Contact() {
            ViewBag.ActiveMenu = "Contact";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginOnebook(UserLoginDto userLogin) {
            try {
                var _user = await _userManager.FindByNameAsync(userLogin.Username);
                if (_user != null) {
                    var rolename = (await _userManager.GetRolesAsync(_user)).FirstOrDefault();
                    var compare = rolename.CompareTo("Sub contact");
                    if (compare == 0) {
                        GlobalData.LoginUserName = userLogin.Username;
                        var subLogin = await SubLogin(userLogin.Username, userLogin.Password);
                        if (subLogin) {
                            var emp = (await app.Employees.QueryAsyncAsNoTracking(x => x.NameTH == userLogin.Username)).FirstOrDefault();

                            if (emp == null) {
                                var gencode = await util.NextCode("EM", "Sub contact employee", 3, true);
                                var employee = new Employee {
                                    EmployeeCode = $"{gencode.Substring(0, 2)}{DateTime.Now:ddMMyy}{gencode.Substring(2, 3)}",
                                    NameTH = userLogin.Username,
                                    NameEN = userLogin.Username,
                                    Position = "Sub contact"
                                };

                                await app.Employees.AddAsync(employee);
                                await app.SaveChangesAsync();
                            }

                            return Json(new { Error = "" });

                        };
                    }
                }

                string password;   //= $"{userLogin.Password}";
                var c = new RestClient("https://apialpha.alphauat.com");
                var r = new RestRequest("http://hr.scgexpress.co.th:8443/api/authen/", Method.POST);
                LoginRequest loginUser = new LoginRequest {
                    Username = userLogin.Username, //"0900000011",
                    Password = userLogin.Password, //
                    Action = "Login",
                    Id = "1",
                    EnvCode = "scg",
                    ProjectCode = "scg"
                };

                r.AddJsonBody(loginUser);

                //  var serealize = System.Text.Json.JsonSerializer.Serialize<LoginRequest>(user);

                var res = c.Execute(r);
                var model = System.Text.Json.JsonSerializer.Deserialize<LoginResponse[]>(res.Content);

                if (model[0].Token == null) {
                    LoginMessage = "Invaid user or password";
                    // return RedirectToAction("Index", "Home");
                    return Json(LoginMessage);
                } else {
                    GlobalData.LoginUserName = loginUser.Username;
                    password = "Initial_1234";
                    var id = model[0].MobileWebRefer;
                    var sql = $"SELECT [scg_employee_id],[name_th],[name_en],[position],[BusinessUnit_Level2],[BusinessUnit_Level3],[BusinessUnit_Level4],[BusinessUnit_Level5],[BusinessUnit_Level6],[division],[branch],[branchCode],[branchName],[Email] ,[SupervisorCode],[SupervisorEmail],[SupervisorPosition] FROM [OnebookDB_SCG].[dbo].[SCG_EMP_Info] WHERE [scg_employee_id]='{id}'";

                    var empView = (await onebookQuery.ViewEmployeeAsync<EmployeeViewModel>(sql)).FirstOrDefault();

                    var empInfo = await app.Employees.SingleOrDefaultAsNoTracking(x => x.EmployeeCode == empView.scg_employee_id);
                    if (empInfo != null) {
                        // login asp
                        var signInResult = await _signInManager.PasswordSignInAsync(
                                            loginUser.Username,
                                            password,
                                            false,
                                            lockoutOnFailure: false);

                        if (signInResult.Succeeded) {
                            GlobalData.UserName = loginUser.Username;
                            var now = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                            var user = await _userManager.FindByNameAsync(loginUser.Username);
                            if (loginUser.Username != "0900000011") {
                                await log.WriteAsync($"{now} : {user.Name} logged in Safety System");
                            }
                            //var words = empInfo.NameEN.Split(' ').ToArray();
                            //GlobalData.UserName = $"Welcome {words[0]}";

                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        } else {
                            LoginMessage = "Invaid user or password";

                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }

                    } else {
                        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                            try {
                                //1/4 add to employee
                                var emp = new Employee();
                                emp.EmployeeCode = empView.scg_employee_id;
                                emp.NameTH = empView.name_th;
                                emp.NameEN = empView.name_en;
                                emp.Position = empView.position;
                                emp.BusinessUnitLevel2 = empView.BusinessUnit_Level2;
                                emp.BusinessUnitLevel3 = empView.BusinessUnit_Level3;
                                emp.BusinessUnitLevel4 = empView.BusinessUnit_Level4;
                                emp.BusinessUnitLevel5 = empView.BusinessUnit_Level5;
                                emp.BusinessUnitLevel6 = empView.BusinessUnit_Level6;
                                emp.Division = empView.division;
                                emp.Branch = empView.branch;
                                emp.BranchCode = empView.branchCode;
                                emp.BranchName = empView.branchName;
                                emp.Email = empView.Email;
                                emp.SupervisorCode = empView.SupervisorCode;
                                emp.SupervisorEmail = empView.SupervisorEmail;
                                emp.SupervisorPosition = empView.SupervisorPosition;

                                await app.Employees.AddAsync(emp);
                                await app.SaveChangesAsync();

                                // check existing role
                                ApplicationRole existingRole = await _roleManager.FindByNameAsync(emp.Position);

                                if (existingRole != null) {
                                    //create user
                                    var user = new ApplicationUser {
                                        Name = emp.NameTH,
                                        UserName = userLogin.Username,
                                        Email = emp.Email
                                    };
                                    var userCreated = await _userManager.CreateAsync(user, password);
                                    if (userCreated.Succeeded) {
                                        var userRoleCreated = await _userManager.AddToRoleAsync(user, existingRole.Name);
                                        if (userRoleCreated.Succeeded) {
                                            //Sign in
                                            var signInResult = await _signInManager.PasswordSignInAsync(loginUser.Username, password, false, lockoutOnFailure: false);

                                            if (signInResult.Succeeded) {
                                                var words = emp.NameEN.Split(' ').ToArray();
                                                GlobalData.UserName = $"Welcome {words[0]}";
                                                scope.Complete();

                                                return RedirectToAction(nameof(HomeController.Index), "Home");

                                            } else {
                                                GlobalData.UserName = signInResult.ToString();
                                            }
                                        }
                                    }

                                } else {
                                    //create role
                                    ApplicationRole role = new ApplicationRole {
                                        CreatedDate = DateTime.Now,
                                        Name = emp.Position,
                                        Description = emp.Position,
                                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                                    };

                                    var roleCreated = await _roleManager.CreateAsync(role);
                                    if (roleCreated.Succeeded) {
                                        //create user
                                        var user = new ApplicationUser {
                                            Name = emp.NameTH,
                                            UserName = userLogin.Username,
                                            Email = emp.Email
                                        };
                                        var userCreated = await _userManager.CreateAsync(user, password);
                                        if (userCreated.Succeeded) {
                                            //get role
                                            ApplicationRole applicationRole = await _roleManager.FindByNameAsync(emp.Position);
                                            if (applicationRole != null) {
                                                // create role and user
                                                var userRoleCreated = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                                if (userRoleCreated.Succeeded) {
                                                    //Sign in
                                                    var signInResult = await _signInManager.PasswordSignInAsync(loginUser.Username, password, false, lockoutOnFailure: false);

                                                    if (signInResult.Succeeded) {
                                                        var words = emp.NameEN.Split(' ').ToArray();
                                                        GlobalData.UserName = $"Welcome {words[0]}";
                                                        scope.Complete();

                                                        return RedirectToAction(nameof(HomeController.Index), "Home");

                                                    } else {
                                                        GlobalData.UserName = signInResult.ToString();
                                                    }
                                                }
                                            }
                                        } else {
                                            LoginMessage = "Invaid user or password";
                                            return RedirectToAction(nameof(HomeController.Index), "Home");
                                        }
                                    }
                                }
                            } catch (Exception ex) {
                                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                                LoginMessage = message;

                                return RedirectToAction(nameof(HomeController.Index), "Home");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                LoginMessage = message;

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(nameof(HomeController.Index), "Home");
        }

        private async Task<bool> SubLogin(string username, string password) {
            try {
                var signInResult = await _signInManager.PasswordSignInAsync(
                                            username,
                                            password,
                                            false,
                                            lockoutOnFailure: false);
                if (!signInResult.Succeeded) return false;
                return true;

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception(message);
            }
        }

        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
