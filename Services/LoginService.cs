using LoginSystem.Models;
using LoginSystem.Repositories;
using LoginSystem.Services.Interfaces;

namespace LoginSystem.Services
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public LoginService(UserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public User? Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
                return null;

            bool validPassword = _passwordService.VerifyPassword(password, user.PasswordHash);

            if (!validPassword)
                return null;

            return user;
        }
    }
}