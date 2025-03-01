using BackEnd.Models;

namespace BackEnd.BusinessLogic
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<User?> Authenticate(string email, string password);
        Task<User> SignUp(User user, string password);
        Task UpdateUser(User user);
        Task<User?> GetUserByEmail(string email);
    }
}