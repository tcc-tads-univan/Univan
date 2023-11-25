namespace Univan.Application.Contracts.Driver
{
    public class VehicleResult
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public string GarageAddress { get; set; }
        public int Seats { get; set; }
    }
}
