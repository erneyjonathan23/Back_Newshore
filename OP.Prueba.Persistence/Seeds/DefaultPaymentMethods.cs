using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Persistence.Seeds
{
    public static class DefaultPaymentMethods
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<MetodosPago>().HasData(new List<MetodosPago>()
            {
                new MetodosPago
                {
                    Id = 1,
                    MetodoPago = "Tarjeta de credito",
                },
                new MetodosPago {
                    Id = 2,
                    MetodoPago = "Tarjeta de debito",
                },
                new MetodosPago {
                    Id = 3,
                    MetodoPago = "Transferencias bancarias electrónicas",
                },
                new MetodosPago {
                    Id = 4,
                    MetodoPago = "Pagos moviles",
                },
                new MetodosPago {
                    Id = 5,
                    MetodoPago = "Efectivo",
                }
            });
        }
    }
}
