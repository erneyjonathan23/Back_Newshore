using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Persistence.Seeds
{
    public static class DefaultGenders
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<Generos>().HasData(new List<Generos>()
            {
                new Generos
                {
                    Id = 1,
                    Genero = "Masculino",
                },
                new Generos {
                    Id = 2,
                    Genero = "Femenino",
                }
            });
        }
    }
}
