using Ardalis.Specification;
using OP.Prueba.Domain.Entities;
using static NPOI.HSSF.Util.HSSFColor;

namespace OP.Prueba.Application.Specifications
{
    public class PagedBookingSpecification : Specification<Reservas>
    {
        public PagedBookingSpecification(int? pageSize, int? pageNumber, int? id, int? usuario, int? estado,
            DateTime? fechaInicio, DateTime? fechaFin, int? tipoViaje, string? origen, string? destino)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (usuario != null && usuario > 0)
                Query.Where(x => x.Usuario == usuario);

            if (tipoViaje != null && tipoViaje > 0)
                Query.Where(x => x.TipoViaje == tipoViaje);

            if (estado != null && estado > 0)
                Query.Where(x => x.Estado == estado);

            if (!string.IsNullOrEmpty(origen))
                Query.Where(x => x.Origen == origen);

            if (!string.IsNullOrEmpty(destino))
                Query.Where(x => x.Destino == destino);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}