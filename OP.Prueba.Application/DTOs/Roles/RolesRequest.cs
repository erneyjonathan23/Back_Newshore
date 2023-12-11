using OP.Prueba.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Roles
{
    public class RolesRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Role { get; set; } = null;
        public int? Nivel { get; set; } = null;
    }
}