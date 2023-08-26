namespace Univan.Api.Contracts.Common
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
