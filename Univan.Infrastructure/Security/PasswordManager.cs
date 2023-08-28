using BCrypt.Net;
using Univan.Application.Abstractions.Security;

namespace Univan.Infrastructure.Security
{
    public class PasswordManager : IPasswordManager
    {
        private const int Iterations = 12;
        public string HashPassword(string password)
        {
           return BCrypt.Net.BCrypt.EnhancedHashPassword(password, Iterations);
        }

        public bool VerifyPassword(string textPassword, string hashPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(textPassword, hashPassword);
        }
    }
}
