using System;
using System.Linq;
using UserService.Data;

namespace UserService.Register
{
    public interface IRegisterService
    {
        User CreateUser(string email, string password);
    }

    public class RegisterService : IRegisterService
    {
        private ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User CreateUser(string email, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_context.Users.Any(x => x.Email == email))
                throw new Exception($"Username {email} is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User { Email = email, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
