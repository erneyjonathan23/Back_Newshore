using MediatR;
using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQuery : IRequest<Response<JourneyDto>>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; }
        public int? FlightType { get; set; }
    }
    public class GetTravelRouteQueryHandler : IRequestHandler<GetTravelRouteQuery, Response<JourneyDto>>
    {
        private readonly IGetTravelRouteService _getTravelRoute;

        public GetTravelRouteQueryHandler(IGetTravelRouteService getTravelRoute)
        {
            this._getTravelRoute = getTravelRoute;
        }
        public async Task<Response<JourneyDto>> Handle(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            var journeyDto = await this._getTravelRoute.Get(request, cancellationToken);
            var prueba = new Response<JourneyDto>()
            {
                Succeeded = journeyDto.Flights.Any() ? true : false,
                Message = journeyDto.Flights.Any() ? "Consulta procesada exitosamente." : "Su consulta no pudo ser procesada.",
                Data = journeyDto
            };
            return prueba;
        }
    }
}
