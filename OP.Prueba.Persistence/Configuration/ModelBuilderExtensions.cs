using Microsoft.EntityFrameworkCore;
using OP.Prueba.Identity.Seeds;
using OP.Prueba.Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Persistence.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            DefaultRoles.Seeds(builder);
            DefaultGenders.Seeds(builder);
            DefaultDocumentTypes.Seeds(builder);
            DefaultPaymentMethods.Seeds(builder);
            DefaultUsers.Seeds(builder);
            DefaultPersons.Seeds(builder);
        }
    }
}
