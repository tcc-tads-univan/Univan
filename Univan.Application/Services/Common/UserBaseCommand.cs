namespace Univan.Application.Services.Common
{
    public class UserBaseCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Stream Photo { get; set; }

        public UserBaseCommand(string name, string email, string password, string cpf, string phoneNumber, DateTime birthdate, Stream photo)
        {
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            Photo = photo;
        }
    }
}
