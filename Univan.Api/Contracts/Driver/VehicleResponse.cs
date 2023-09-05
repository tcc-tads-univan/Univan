﻿namespace Univan.Api.Contracts.Driver
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int Seats { get; set; }
    }
}
