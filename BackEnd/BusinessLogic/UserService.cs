using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
// using System.Security.Cryptography;
// using System.Threading.Tasks;
// using System.Text;

namespace BackEnd.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);

            if (user == null || user.password != password)
            {
                return null;
            }

            return user;
        }

        public async Task<User> SignUp(User user, string password)
        {
            user.password = password;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // private string HashPassword(string password)
        // {
        //     using var sha256 = SHA256.Create();
        //     var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //     return Convert.ToBase64String(bytes);
        // }
        // private bool VerifyPassword(string password, string storedHash)
        // {
        //     return HashPassword(password) == storedHash;
        // }

    }
}