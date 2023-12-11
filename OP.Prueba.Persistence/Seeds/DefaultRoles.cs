using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Persistence.Seeds
{
    public static class DefaultRoles
    {
        public static void Seeds(ModelBuilder builder)
        {
            builder.Entity<Roles>().HasData(new List<Roles>()
            {
                new Roles
                {
                    Id = 1,
                    Role = "Admin",
                    Nivel = (int)Application.Enums.Roles.Admin,
                },
                new Roles {
                    Id = 2,
                    Role = "Cliente",
                    Nivel = (int)Application.Enums.Roles.Cliente,
                }
            });
        }
    }
}
