namespace Univan.Application.Abstractions.Security
{
    public interface IPasswordManager
    {
        string HashPassword(string password);
        bool VerifyPassword(string textPassword, string hashPassword);
    }
}
