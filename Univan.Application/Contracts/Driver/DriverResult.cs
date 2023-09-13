using Univan.Application.Contracts.Common;

namespace Univan.Application.Contracts.Driver
{
    public class DriverResult : UserResult
    {
        public string Cnh { get; set; }
        public int? VehicleId { get; set; }
    }   
}
