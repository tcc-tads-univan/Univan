using Univan.Domain.Enums;

namespace Univan.Application.Contracts.Authentication
{
    public class AuthenticationResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public UserType UserType { get; set; }
    }
}
