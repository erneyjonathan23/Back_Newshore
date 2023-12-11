using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedBookingPersonSpecification : Specification<ReservaPersonas>
    {
        public PagedBookingPersonSpecification(int? pageSize, int? pageNumber, int? id, int? persona, int? reserva)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (persona != null && persona > 0)
                Query.Where(x => x.Persona == persona);

            if (reserva != null && reserva > 0)
                Query.Where(x => x.Reserva == reserva);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}