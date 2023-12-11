using OP.Prueba.Application.DTOs.Genders;
using OP.Prueba.Application.Features.Gender.Queries.GetAllGendersQuery;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IGenderService
    {
        Task<PagedResponse<List<GendersDto>>> GetAllGenders(GetAllGendersQuery request, CancellationToken cancellationToken);
    }
}