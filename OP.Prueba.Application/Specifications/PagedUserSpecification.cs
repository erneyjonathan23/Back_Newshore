using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedUserSpecification : Specification<Usuarios>
    {
        public PagedUserSpecification(int? pageSize, int? pageNumber, int? id, string? usuario)
        {
            if (!string.IsNullOrEmpty(usuario))
                Query.Where(x => x.Usuario == usuario);

            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}
