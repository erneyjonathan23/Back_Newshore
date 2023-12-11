using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OP.Prueba.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactoEmergencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    NumeroContacto = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContactoEmergencia__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Generos__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPago = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MetodosPago__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: true),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    TipoDocumento = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposDocumento__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC078BF374BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Role",
                        column: x => x.Role,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    TelefonoContacto = table.Column<long>(type: "bigint", nullable: false),
                    Usuario = table.Column<int>(type: "int", nullable: true),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personas__3214EC078BF374BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento",
                        column: x => x.TipoDocumento,
                        principalTable: "TiposDocumento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<int>(type: "int", nullable: false),
                    TipoViaje = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Destino = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    ContactoEmergencia = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    NumeroPersonas = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__3214EC078BF374BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_ContactoEmergencia",
                        column: x => x.ContactoEmergencia,
                        principalTable: "ContactoEmergencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservaPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona = table.Column<int>(type: "int", nullable: false),
                    Reserva = table.Column<int>(type: "int", nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReservaPersonas__3214EC078BF374BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaPersona_Persona",
                        column: x => x.Persona,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservaPersona_Reserva",
                        column: x => x.Reserva,
                        principalTable: "Reservas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "FeBaja", "FeRegistro", "Genero" },
                values: new object[,]
                {
                    { 1, null, null, "Masculino" },
                    { 2, null, null, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "MetodosPago",
                columns: new[] { "Id", "FeBaja", "FeRegistro", "MetodoPago" },
                values: new object[,]
                {
                    { 1, null, null, "Tarjeta de credito" },
                    { 2, null, null, "Tarjeta de debito" },
                    { 3, null, null, "Transferencias bancarias electrónicas" },
                    { 4, null, null, "Pagos moviles" },
                    { 5, null, null, "Efectivo" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "FeBaja", "FeRegistro", "Nivel", "Role" },
                values: new object[,]
                {
                    { 1, null, null, 1, "Admin" },
                    { 2, null, null, 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "Id", "Codigo", "FeBaja", "FeRegistro", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "CC", null, null, "Cedula ciudadania" },
                    { 2, "TI", null, null, "Tarjeta de identidad" },
                    { 3, "NIUP", null, null, "Número único de identificación personal" },
                    { 4, "NIP", null, null, "Número de Identificación personal" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contrasena", "FeBaja", "FeRegistro", "Role", "Usuario" },
                values: new object[] { 1, "De1234567", null, null, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellidos", "Email", "FeBaja", "FeRegistro", "FechaNacimiento", "Genero", "Nombres", "NumeroDocumento", "TelefonoContacto", "TipoDocumento", "Usuario" },
                values: new object[] { 1, "Admin", "Admin@smartalentit.com", null, null, new DateTime(1999, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Admin", "1017270383", 3113643147L, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Genero",
                table: "Personas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas",
                column: "NumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoDocumento",
                table: "Personas",
                column: "TipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Usuario",
                table: "Personas",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPersonas_Persona",
                table: "ReservaPersonas",
                column: "Persona");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPersonas_Reserva",
                table: "ReservaPersonas",
                column: "Reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ContactoEmergencia",
                table: "Reservas",
                column: "ContactoEmergencia");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Usuario",
                table: "Reservas",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Role",
                table: "Usuarios",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Usuario",
                table: "Usuarios",
                column: "Usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetodosPago");

            migrationBuilder.DropTable(
                name: "ReservaPersonas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TiposDocumento");

            migrationBuilder.DropTable(
                name: "ContactoEmergencia");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
