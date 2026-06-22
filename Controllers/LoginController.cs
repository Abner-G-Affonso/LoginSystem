using LoginSystem.Services;
using LoginSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // Tela de login
        public IActionResult Index()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _loginService.Login(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Email ou senha inválidos");
                return View(model);
            }

            // Aqui depois vamos criar sessão
            return RedirectToAction("Index", "Home");
        }
    }
}