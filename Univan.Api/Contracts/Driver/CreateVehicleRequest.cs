namespace Univan.Api.Contracts.Driver
{
    public class CreateVehicleRequest
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int Seats { get; set; }
    }
}
