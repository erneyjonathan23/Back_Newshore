using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Users
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Nivel { get; set; }
        public int Role { get; set; }
        public virtual Domain.Entities.Roles RoleNavigation { get; set; } = null!;
        public virtual Personas? PersonaNavigation { get; set; } = null;
    }
}
