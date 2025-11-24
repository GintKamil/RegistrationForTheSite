using Microsoft.AspNetCore.Mvc;
using RegistrationSite.Model;
using RegistrationSite.Services;

namespace RegistrationSite.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHashingService _hashingService;

        public AuthorizationController(IUserService userService, IHashingService hashingService)
        {
            _userService = userService;
            _hashingService = hashingService;
        }

        [Route("authorization")]
        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [Route("authorization")]
        [HttpPost]
        public IActionResult Authorization(string action, UserModel model)
        {
            if(action == "RegistrationButton")
                return RedirectToAction("Register", "Register");

            else
            {
                var GetModel = _userService.Get(model.Email).Result;
                if (GetModel != null)
                {
                    if (_hashingService.PasswordCheck(GetModel.Password, model.Password))
                    {
                        TempData["name"] = GetModel.Name;
                        TempData["email"] = GetModel.Email;
                        TempData["age"] = GetModel.Age;
                        
                        return RedirectToAction("Index", "Account");
                    }
                    else 
                    {
                        TempData["ErrorMessage"] = "Неверный email или пароль";
                        return View(model);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Неверный email или пароль";
                    return View(model);
                }
                
            }
        }
    }
}
