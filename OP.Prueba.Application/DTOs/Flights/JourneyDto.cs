using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.DTOs.Flights
{
    public class JourneyDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
