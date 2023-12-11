// ***********************************************************************
// Assembly         : OP.Prueba.WebAPI
// Author           : Jonathan Puerta
// Created          : 10-12-2023
//
// Last Modified By : Jonathan Puerta
// Last Modified On : Jonathan Puerta
// ***********************************************************************
// <copyright file="FlightController.cs" company="OP.Prueba.WebAPI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Prueba.Application.DTOs.Flights;
using OP.Prueba.Application.Features.Flight.Queries.GetAllTravelRoutesQuery;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    /// <summary>
    /// Class FlightController.
    /// Implements the <see cref="BaseApiController" />
    /// </summary>
    /// <seealso cref="BaseApiController" />
    [ApiVersion("1.0")]
    public class FlightController : BaseApiController
    {
        /// GET api/<controller>
        /// <summary>
        /// Obtains the information related to Documento, under a set of requests defined in the request
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Return code 200, when process are correct, with the list of records that comply with the application of all request requests</response>
        /// <response code="204">Return code 204, when The request resource could not be found results in the service</response>
        /// <response code="400">Return code 400, when the registry are wrong in any field, and the server don't process the request</response>
        /// <response code="500">Return code 500, when produce a internal error during process the request into the service, the response contains description about error</response>
        /// <remarks>Sample request:
        /// GET
        /// {
        /// "id": 5
        /// }</remarks>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FlightsRequest request)
        {
            return Ok(await Mediator.Send(new GetTravelRouteQuery
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Currency = request.Currency,
                FlightType = request.FlightType,
            }));
        }
        [HttpGet("AllTravelRoute")]
        public async Task<IActionResult> GetAllTravelRoutes([FromQuery] FlightsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllTravelRoutesQuery
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Currency = request.Currency,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
            }));
        }
    }
}