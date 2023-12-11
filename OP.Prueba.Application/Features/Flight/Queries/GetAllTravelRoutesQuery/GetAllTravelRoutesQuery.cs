using MediatR;
using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Features.Flight.Queries.GetAllTravelRoutesQuery
{
    public class GetAllTravelRoutesQuery : IRequest<PagedResponse<List<ResponseFlightsDto>>>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class GetAllTravelRoutesQueryHandler : IRequestHandler<GetAllTravelRoutesQuery, PagedResponse<List<ResponseFlightsDto>>>
    {
        private readonly IGetTravelRouteService _getTravelRoute;

        public GetAllTravelRoutesQueryHandler(IGetTravelRouteService getTravelRoute)
        {
            this._getTravelRoute = getTravelRoute;
        }
        public async Task<PagedResponse<List<ResponseFlightsDto>>> Handle(GetAllTravelRoutesQuery request, CancellationToken cancellationToken)
        {
            return await this._getTravelRoute.GetAllTravelRoutes(request, cancellationToken);
        }
    }
}
