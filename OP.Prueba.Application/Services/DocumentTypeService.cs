using AutoMapper;
using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.DocumentType.Queries.GetAllDocumentTypesQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IRepositoryAsync<Domain.Entities.TiposDocumento> _repositoryAsync;
        private readonly IMapper _mapper;
        public DocumentTypeService(IRepositoryAsync<TiposDocumento> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<PagedResponse<List<DocumentTypesDto>>> GetAllDocumentTypes(GetAllDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            var documentType = await _repositoryAsync.ListAsync(new PagedDocumentTypeSpecification(request.PageSize, request.PageNumber, request.Id, request.TipoDocumento, request.Codigo));
            var documentTypeCount = await _repositoryAsync.CountAsync(new PagedDocumentTypeSpecification(null, null, request.Id, request.TipoDocumento, request.Codigo));
            var documentTypeDto = new List<DocumentTypesDto>();
            if (documentType.Count > 0)
            {
                documentTypeDto = (from data in documentType
                                   select new DocumentTypesDto
                                   {
                                       Id = data.Id,
                                       TipoDocumento = data.TipoDocumento,
                                       Codigo = data.Codigo,
                                       Personas = data.Personas,
                                       FeBaja = data.FeBaja,
                                       FeRegistro = data.FeRegistro
                                   }).ToList();
            }
            return new PagedResponse<List<DocumentTypesDto>>(documentTypeDto, request.PageNumber, request.PageSize, documentTypeCount);
        }
    }
}