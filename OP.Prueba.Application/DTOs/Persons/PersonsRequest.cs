using OP.Prueba.Application.Parameters;

namespace OP.Prueba.Application.DTOs.Persons
{
    public class PersonsRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? Nombres { get; set; } = null;
        public string? Apellidos { get; set; } = null;
        public DateTime? FechaNacimiento { get; set; } = null;
        public int? Genero { get; set; } = null;
        public int? TipoDocumento { get; set; } = null;
        public string? NumeroDocumento { get; set; } = null;
        public string? Email { get; set; } = null;
        public long? TelefonoContacto { get; set; } = null;
        public int? Usuario { get; set; } = null;
    }
}
