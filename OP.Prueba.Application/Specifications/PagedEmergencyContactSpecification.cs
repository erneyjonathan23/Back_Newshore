using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedEmergencyContactSpecification : Specification<ContactoEmergencia>
    {
        public PagedEmergencyContactSpecification(int? pageSize, int? pageNumber, int? id, string? nombres, string? apellidos, long? numeroContacto, string? email)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (numeroContacto != null && numeroContacto > 0)
                Query.Where(x => x.NumeroContacto == numeroContacto);

            if (!string.IsNullOrEmpty(nombres))
                Query.Where(x => x.Nombres == nombres);

            if (!string.IsNullOrEmpty(apellidos))
                Query.Where(x => x.Apellidos == apellidos);

            if (!string.IsNullOrEmpty(email))
                Query.Where(x => x.Email == email);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}