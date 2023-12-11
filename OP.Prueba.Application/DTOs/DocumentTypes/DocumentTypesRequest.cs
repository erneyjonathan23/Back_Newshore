using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OP.Prueba.Application.DTOs.DocumentTypes
{
    public class DocumentTypesRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Codigo { get; set; } = null;
        public string? TipoDocumento { get; set; } = null;
    }
}