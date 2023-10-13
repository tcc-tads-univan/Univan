namespace Univan.Domain.Entities
{
    public class Student : User
    {
        public Address Address { get; set; }
        public int? AddressId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
