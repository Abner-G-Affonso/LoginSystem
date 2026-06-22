using LoginSystem.Models;
using LoginSystem.Repositories;
using LoginSystem.Services.Interfaces;

namespace LoginSystem.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(UserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public bool EmailExists(string email)
        {
            return _userRepository.EmailExists(email);
        }

        public void Register(string name, string email, string password)
        {
            if (EmailExists(email))
                throw new Exception("E-mail já cadastrado.");

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = _passwordService.HashPassword(password),
                CreatedAt = DateTime.Now
            };

            _userRepository.Insert(user);
        }
    }
}