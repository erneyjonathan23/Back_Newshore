using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.DTOs.Genders
{
    public class GendersRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Genero { get; set; } = null;
    }
}
