using LoginSystem.Services;
using LoginSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Tela de cadastro
        public IActionResult Register()
        {
            return View();
        }

        // Cadastro POST
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _userService.Register(
                    model.Name,
                    model.Email,
                    model.Password
                );

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}