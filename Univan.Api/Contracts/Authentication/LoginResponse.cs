namespace Univan.Api.Contracts.Authentication
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
