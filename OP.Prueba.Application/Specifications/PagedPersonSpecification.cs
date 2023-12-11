using Ardalis.Specification;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Specifications
{
    public class PagedPersonSpecification : Specification<Personas>
    {
        public PagedPersonSpecification(int? pageSize, int? pageNumber, int? id, int? usuario, string? nombres, string? apellidos, int? genero,
            int? tipoDocumento, string? numeroDocumento, string? email, long? telefonoContacto)
        {
            if (id != null && id > 0)
                Query.Where(x => x.Id == id);

            if (usuario != null && usuario > 0)
                Query.Where(x => x.Usuario == usuario);

            if (!string.IsNullOrEmpty(nombres))
                Query.Where(x => x.Nombres == nombres);

            if (!string.IsNullOrEmpty(apellidos))
                Query.Where(x => x.Apellidos == apellidos);

            if (genero != null && genero > 0)
                Query.Where(x => x.Genero == genero);

            if (tipoDocumento != null && tipoDocumento > 0)
                Query.Where(x => x.TipoDocumento == tipoDocumento);

            if (!string.IsNullOrEmpty(numeroDocumento))
                Query.Where(x => x.NumeroDocumento == numeroDocumento);

            if (!string.IsNullOrEmpty(email))
                Query.Where(x => x.Email == email);

            if (telefonoContacto != null && telefonoContacto > 0)
                Query.Where(x => x.TelefonoContacto == telefonoContacto);

            if (pageSize != null && pageNumber != null)
                Query.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize);
        }
    }
}
