using AutoMapper;
using OP.Prueba.Application.DTOs.Genders;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.Gender.Queries.GetAllGendersQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IRepositoryAsync<Domain.Entities.Generos> _repositoryAsync;
        private readonly IMapper _mapper;
        public GenderService(IRepositoryAsync<Generos> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<PagedResponse<List<GendersDto>>> GetAllGenders(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            var Genders = await _repositoryAsync.ListAsync(new PagedGenderSpecification(request.PageSize, request.PageNumber, request.Id, request.Genero));
            var GendersCount = await _repositoryAsync.CountAsync(new PagedGenderSpecification(null, null, request.Id, request.Genero));
            var GendersDto = new List<GendersDto>();
            if (Genders.Count > 0)
            {
                GendersDto = (from data in Genders
                              select new GendersDto
                              {
                                  Id = data.Id,
                                  Genero = data.Genero,
                                  Personas = data.Personas,
                                  FeBaja = data.FeBaja,
                                  FeRegistro = data.FeRegistro
                              }).ToList();
            }
            return new PagedResponse<List<GendersDto>>(GendersDto, request.PageNumber, request.PageSize, GendersCount);
        }
    }
}