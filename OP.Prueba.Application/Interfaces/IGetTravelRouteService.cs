using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Application.Features.Flight.Queries.GetAllTravelRoutesQuery;
using OP.Prueba.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IGetTravelRouteService
    {
        Task<JourneyDto> Get(GetTravelRouteQuery request, CancellationToken cancellationToken);
        Task<PagedResponse<List<ResponseFlightsDto>>> GetAllTravelRoutes(GetAllTravelRoutesQuery request, CancellationToken cancellationToken);
    }
}
