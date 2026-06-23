using LoginSystem.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace LoginSystem.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _http;

        private const string KEY = "LoggedUser";

        public SessionService(IHttpContextAccessor http)
        {
            _http = http;
        }

        private ISession Session =>
            _http.HttpContext?.Session
            ?? throw new InvalidOperationException("Session não disponível");

        public void Login(User user)
        {
            var json = JsonSerializer.Serialize(user);
            Session.SetString(KEY, json);
        }

        public User? GetUser()
        {
            var json = Session.GetString(KEY);

            return json == null
                ? null
                : JsonSerializer.Deserialize<User>(json);
        }

        public void Logout()
        {
            Session.Remove(KEY);
        }

        public bool IsLogged()
        {
            return GetUser() != null;
        }
    }
}