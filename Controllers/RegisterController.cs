using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationSite.Model;
using RegistrationSite.Services;
using System.Reflection;

namespace RegistrationSite.Controllers
{
    public class RegisterController: Controller
    {
        private IUserService _userService;
        private readonly IHashingService _hashingService;
        public RegisterController(IUserService userService, IHashingService hashingService)
        {
            _userService = userService;
            _hashingService = hashingService;
        }

        [Route("registration")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("registration")]
        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            Console.WriteLine("ok");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Пользователь " + model.Name);
                model.Password = _hashingService.PasswordHashing(model.Password);
                Console.WriteLine(model.ToString());
                _userService.Create(model);

                TempData["name"] = model.Name;
                TempData["email"] = model.Email;
                TempData["age"] = model.Age;

                return RedirectToAction("Index", "Account");
            }
            return View(model);
        }
    }
}
