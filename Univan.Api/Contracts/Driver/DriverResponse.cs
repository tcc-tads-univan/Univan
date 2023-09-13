using Univan.Api.Contracts.Common;

namespace Univan.Api.Contracts.Driver
{
    public class DriverResponse : UserResponse
    {
        public string Cnh { get; set; }

        public int VehicleId { get; set; }
    }
}
