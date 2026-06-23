using LoginSystem.Services;
using LoginSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        private readonly SessionService _sessionService;

        public LoginController(LoginService loginService, SessionService sessionService)
        {
            _loginService = loginService;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View();
        }

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

            // 🔐 salva usuário na sessão
            _sessionService.Login(user);

            return RedirectToAction("Index", "Home");
        }
    }
}