using LoginSystem.Models;

namespace LoginSystem.Services.Interfaces
{
    public interface IUserService
    {
        void Register(string name, string email, string password);
        bool EmailExists(string email);
    }
}