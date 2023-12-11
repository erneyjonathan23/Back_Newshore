using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.Features.DocumentType.Queries.GetAllDocumentTypesQuery;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DocumentTypesController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult> Get([FromQuery] DocumentTypesRequest request)
        {
            return Ok(await Mediator.Send(new GetAllDocumentTypesQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                TipoDocumento = request.TipoDocumento,
                Codigo = request.Codigo,
            }));
        }
    }
}