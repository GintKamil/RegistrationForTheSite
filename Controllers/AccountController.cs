using Microsoft.AspNetCore.Mvc;

namespace RegistrationSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("account")]
        public IActionResult Index()
        {
            string? name = TempData["name"] as string;
            string? email = TempData["email"] as string;
            string? age = TempData["age"] as string;

            if (name == null && email == null)
                return RedirectToAction("Authorization", "Authorization");
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Age = age;
            return View();
        }

        [HttpPost]
        public IActionResult Logout() =>
            RedirectToAction("Authorization", "Authorization");

    }
}
