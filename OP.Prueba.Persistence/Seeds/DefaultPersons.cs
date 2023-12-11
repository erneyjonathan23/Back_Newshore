using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Identity.Seeds
{
    public static class DefaultPersons
    {
        public static void Seeds(ModelBuilder builder)
        {
            var defaultPerson = new Personas
            {
                Id = 1,
                Nombres = "Admin",
                Apellidos = "Admin",
                FechaNacimiento = new DateTime(1999, 4, 15),
                Genero = (int)Application.Enums.Generos.Masculino,
                TipoDocumento = (int)Application.Enums.TiposDocumentos.CedulaCiudadania,
                NumeroDocumento = "1017270383",
                Email = "Admin@smartalentit.com",
                TelefonoContacto = 3113643147,
                Usuario = 1,
            };
            builder.Entity<Personas>().HasData(defaultPerson);
        }
    }
}
