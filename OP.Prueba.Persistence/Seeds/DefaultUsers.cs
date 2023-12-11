using Microsoft.EntityFrameworkCore;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Identity.Seeds
{
    public static class DefaultUsers
    {
        public static void Seeds(ModelBuilder builder)
        {
            var defaultUser = new Usuarios
            {
                Id = 1,
                Usuario = "Admin",
                Contrasena = "De1234567",
                Role = (int)Application.Enums.Roles.Admin
            };
            builder.Entity<Usuarios>().HasData(defaultUser);
        }
    }
}
