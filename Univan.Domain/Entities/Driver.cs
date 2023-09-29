namespace Univan.Domain.Entities
{
    public class Driver : User
    {
        public string Cnh { get; set; }
        public Vehicle Vehicle { get; set; }
        public int? VehicleId { get; set; }
        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
