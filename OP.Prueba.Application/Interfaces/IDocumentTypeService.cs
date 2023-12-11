using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.DTOs.Users;
using OP.Prueba.Application.Features.DocumentType.Queries.GetAllDocumentTypesQuery;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<PagedResponse<List<DocumentTypesDto>>> GetAllDocumentTypes(GetAllDocumentTypesQuery request, CancellationToken cancellationToken);
    }
}