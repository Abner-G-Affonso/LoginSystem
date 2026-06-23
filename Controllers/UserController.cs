using LoginSystem.Services.Interfaces;
using LoginSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Tela de cadastro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Cadastro POST
        [HttpPost]
        [ValidateAntiForgeryToken]
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

                TempData["Success"] = "Usuário criado com sucesso!";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
    }
}