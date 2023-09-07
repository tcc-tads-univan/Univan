namespace Univan.Api.Contracts.Common
{
    public abstract class UserCreateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
