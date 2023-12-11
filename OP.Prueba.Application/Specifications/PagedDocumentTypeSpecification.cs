using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedDocumentTypeSpecification : Specification<TiposDocumento>
    {
        public PagedDocumentTypeSpecification(int? pageSize, int? pageNumber, int? id, string? tipoDocumento, string? codigo)
        {
            if (!string.IsNullOrEmpty(tipoDocumento))
                Query.Where(x => x.TipoDocumento == tipoDocumento);

            if (!string.IsNullOrEmpty(codigo))
                Query.Where(x => x.Codigo == codigo);

            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}
