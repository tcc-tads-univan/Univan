namespace Univan.Application.Services.Common
{
    public class UserUpdateBaseCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Stream Photo { get; set; }

        public UserUpdateBaseCommand(int id, string name, string password, string phoneNumber, DateTime birthdate, Stream photo)
        {
            Id = id;
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            Photo = photo;
        }
    }
}
