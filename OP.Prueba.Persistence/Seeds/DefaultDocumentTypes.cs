using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Persistence.Seeds
{
    public static class DefaultDocumentTypes
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<TiposDocumento>().HasData(new List<TiposDocumento>()
            {
                new TiposDocumento
                {
                    Id = 1,
                    TipoDocumento = "Cedula ciudadania",
                    Codigo = "CC"
                },
                new TiposDocumento {
                    Id = 2,
                    TipoDocumento = "Tarjeta de identidad",
                    Codigo = "TI"
                },
                new TiposDocumento {
                    Id = 3,
                    TipoDocumento = "Número único de identificación personal",
                    Codigo = "NIUP"
                },
                new TiposDocumento {
                    Id = 4,
                    TipoDocumento = "Número de Identificación personal",
                    Codigo = "NIP"
                }
            });
        }
    }
}
