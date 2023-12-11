using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedRoleSpecification : Specification<Roles>
    {
        public PagedRoleSpecification(int? pageSize, int? pageNumber, int? id, string? role, int? nivel)
        {
            if (!string.IsNullOrEmpty(role))
                Query.Where(x => x.Role == role);

            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (nivel != null && nivel > 0)
                Query.Where(x => x.Nivel == nivel);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}
