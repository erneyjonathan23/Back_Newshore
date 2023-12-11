using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.Genders;
using OP.Prueba.Application.Features.Gender.Queries.GetAllGendersQuery;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class GendersController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult> Get([FromQuery] GendersRequest request)
        {
            return Ok(await Mediator.Send(new GetAllGendersQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Genero = request.Genero
            }));
        }
    }
}