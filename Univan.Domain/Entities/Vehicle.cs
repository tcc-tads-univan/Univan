namespace Univan.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public string GaragePlaceId { get; set; }
        public int Seats { get; set; }
        public Driver Driver { get; set; }
    }
}
