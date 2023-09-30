namespace Univan.Application.Abstractions.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, string name);
    }
}
