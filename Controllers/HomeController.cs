using LoginSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SessionService _sessionService;

        public HomeController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            if (!_sessionService.IsLogged())
                return RedirectToAction("Index", "Login");

            ViewBag.User = _sessionService.GetUser();

            return View();
        }

        public IActionResult Logout()
        {
            _sessionService.Logout();
            return RedirectToAction("Index", "Login");
        }
    }
}