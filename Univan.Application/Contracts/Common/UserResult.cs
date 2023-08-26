namespace Univan.Application.Contracts.Common
{
    public class UserResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Rating { get; set; }
        public string PhotoUrl { get; set; }
    }
}
