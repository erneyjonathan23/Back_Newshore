using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedPaymentMethodSpecification : Specification<MetodosPago>
    {
        public PagedPaymentMethodSpecification(int? pageSize, int? pageNumber, int? id, string? metodoPago)
        {
            if (!string.IsNullOrEmpty(metodoPago))
                Query.Where(x => x.MetodoPago == metodoPago);

            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}
