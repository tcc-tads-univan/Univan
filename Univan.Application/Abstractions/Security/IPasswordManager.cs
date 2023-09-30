namespace Univan.Application.Abstractions.Security
{
    public interface IPasswordManager
    {
        string HashPassword(string password);
        bool IsValidPassword(string textPassword, string hashPassword);
    }
}
