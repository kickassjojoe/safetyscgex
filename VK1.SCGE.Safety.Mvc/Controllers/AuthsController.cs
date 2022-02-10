using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using VK1.SCGE.Safety.Mvc.Dtos;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class AuthsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Login(UserLoginDto userLogin) {
            try {
                var c = new RestClient("https://apialpha.alphauat.com");
                var r = new RestRequest("http://hr.scgexpress.co.th:8443/api/authen/", Method.POST);
                LoginRequest user = new LoginRequest {
                    Username = userLogin.Username, //"0900000011",
                    Password = userLogin.Password, //
                    Action = "Login",
                    Id = "1",
                    EnvCode = "scg",
                    ProjectCode = "scg"
                };

                r.AddJsonBody(user);

                //  var serealize = System.Text.Json.JsonSerializer.Serialize<LoginRequest>(user);

                var res = c.Execute(r);
                var model = System.Text.Json.JsonSerializer.Deserialize<LoginResponse[]>(res.Content);

                if (model[0].Token == null) {
                  //  LoginMessage = "Username or Password is invaid";

                    return RedirectToAction("Index", "Home");
                }

                return View();

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ViewBag.Message = message;
            }

            return View();
        }
    }
}
