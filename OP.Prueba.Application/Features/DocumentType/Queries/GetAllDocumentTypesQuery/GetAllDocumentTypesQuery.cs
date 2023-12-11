using MediatR;
using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.DocumentType.Queries.GetAllDocumentTypesQuery
{
    public class GetAllDocumentTypesQuery : IRequest<PagedResponse<List<DocumentTypesDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Codigo { get; set; } = null;
        public string? TipoDocumento { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllDocumentTypesQuery, PagedResponse<List<DocumentTypesDto>>>
    {
        private readonly IDocumentTypeService _documentTypeService;

        public GetAllRolesQueryHandler(IDocumentTypeService documentTypeService)
        {
            this._documentTypeService = documentTypeService;
        }

        public async Task<PagedResponse<List<DocumentTypesDto>>> Handle(GetAllDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            return await _documentTypeService.GetAllDocumentTypes(request, cancellationToken);
        }
    }
}
