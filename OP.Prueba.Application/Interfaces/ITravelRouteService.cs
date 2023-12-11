using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Interfaces
{
    public interface ITravelRouteService
    {
        Task<List<Flight>> GenerateFlightRoute(string Origin, string Destination, string currency, List<ResponseFlightsDto> Flights,
            CancellationToken cancellationToken);
    }
}
