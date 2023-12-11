namespace OP.Prueba.Application.DTOs.Flights
{
    public class FlightsRequest
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? Currency { get; set; } = "USD";
        public int? FlightType { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
