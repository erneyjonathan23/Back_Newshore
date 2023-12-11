using Microsoft.Extensions.Configuration;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.Flight.Queries.GetAllTravelRoutesQuery;
using OP.Prueba.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Shared.Services
{
    public class GetTravelRouteService : IGetTravelRouteService
    {
        private readonly IGenericClientHttpService _genericlient;
        private readonly ITravelRouteService _travelRoute;
        public IConfiguration _configuration { get; set; }

        public GetTravelRouteService(IGenericClientHttpService genericlient, ITravelRouteService travelRoute, IConfiguration configuration)
        {
            this._genericlient = genericlient;
            this._travelRoute = travelRoute;
            this._configuration = configuration;
        }
        public async Task<JourneyDto> Get(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            List<ResponseFlightsDto> ResponseFlightsDto = await this._genericlient.GetRequestAsync<List<ResponseFlightsDto>>(
                this._configuration["ServiceUrls:NewshoreRecruiting"], cancellationToken, string.Empty);
            var Flights = await this._travelRoute.GenerateFlightRoute(request.Origin, request.Destination,
                request.Currency, ResponseFlightsDto, cancellationToken);

            return new JourneyDto()
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Price = Flights.Select(s => s.Price).Sum(),
                Flights = Flights
            };
        }

        public async Task<PagedResponse<List<ResponseFlightsDto>>> GetAllTravelRoutes(GetAllTravelRoutesQuery request, CancellationToken cancellationToken)
        {
            List<ResponseFlightsDto> ResponseFlightsDto = await this._genericlient.GetRequestAsync<List<ResponseFlightsDto>>(
                this._configuration["ServiceUrls:NewshoreRecruiting"], cancellationToken, string.Empty);

            var count = ResponseFlightsDto.Count();
            ResponseFlightsDto = ResponseFlightsDto.Skip(((int)request.PageNumber - 1) * (int)request.PageSize)
                .Take((int)request.PageSize).ToList();

            return new PagedResponse<List<ResponseFlightsDto>>(ResponseFlightsDto, (int)request.PageNumber, (int)request.PageSize, count);
        }
    }
}
