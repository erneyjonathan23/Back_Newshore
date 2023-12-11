using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedGenderSpecification : Specification<Generos>
    {
        public PagedGenderSpecification(int? pageSize, int? pageNumber, int? id, string? genero)
        {
            if (!string.IsNullOrEmpty(genero))
                Query.Where(x => x.Genero == genero);

            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}