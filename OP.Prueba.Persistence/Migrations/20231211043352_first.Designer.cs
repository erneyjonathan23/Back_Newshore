﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OP.Prueba.Persistence.Context;

#nullable disable

namespace OP.Prueba.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231211043352_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OP.Prueba.Domain.Entities.ContactoEmergencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<long>("NumeroContacto")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__ContactoEmergencia__3214EC078BF374BA");

                    b.ToTable("ContactoEmergencia", (string)null);
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Generos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("PK__Generos__3214EC078BF374BA");

                    b.ToTable("Generos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genero = "Masculino"
                        },
                        new
                        {
                            Id = 2,
                            Genero = "Femenino"
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.MetodosPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("PK__MetodosPago__3214EC078BF374BA");

                    b.ToTable("MetodosPago", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MetodoPago = "Tarjeta de credito"
                        },
                        new
                        {
                            Id = 2,
                            MetodoPago = "Tarjeta de debito"
                        },
                        new
                        {
                            Id = 3,
                            MetodoPago = "Transferencias bancarias electrónicas"
                        },
                        new
                        {
                            Id = 4,
                            MetodoPago = "Pagos moviles"
                        },
                        new
                        {
                            Id = 5,
                            MetodoPago = "Efectivo"
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Personas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<long?>("TelefonoContacto")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("int");

                    b.Property<int?>("Usuario")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Personas__3214EC078BF374BA");

                    b.HasIndex("Genero");

                    b.HasIndex("NumeroDocumento");

                    b.HasIndex("TipoDocumento");

                    b.HasIndex("Usuario");

                    b.ToTable("Personas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Admin",
                            Email = "Admin@smartalentit.com",
                            FechaNacimiento = new DateTime(1999, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Admin",
                            NumeroDocumento = "1017270383",
                            TelefonoContacto = 3113643147L,
                            TipoDocumento = 1,
                            Usuario = 1
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.ReservaPersonas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Persona")
                        .HasColumnType("int");

                    b.Property<int>("Reserva")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__ReservaPersonas__3214EC078BF374BA");

                    b.HasIndex("Persona");

                    b.HasIndex("Reserva");

                    b.ToTable("ReservaPersonas", (string)null);
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContactoEmergencia")
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar");

                    b.Property<int?>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime");

                    b.Property<int?>("NumeroPersonas")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TipoViaje")
                        .HasColumnType("int");

                    b.Property<int>("Usuario")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Reservas__3214EC078BF374BA");

                    b.HasIndex("ContactoEmergencia");

                    b.HasIndex("Usuario");

                    b.ToTable("Reservas", (string)null);
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("PK__Roles__3214EC078BF374BA");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nivel = 1,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Nivel = 2,
                            Role = "Cliente"
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.TiposDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("PK__TiposDocumento__3214EC078BF374BA");

                    b.ToTable("TiposDocumento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "CC",
                            TipoDocumento = "Cedula ciudadania"
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "TI",
                            TipoDocumento = "Tarjeta de identidad"
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "NIUP",
                            TipoDocumento = "Número único de identificación personal"
                        },
                        new
                        {
                            Id = 4,
                            Codigo = "NIP",
                            TipoDocumento = "Número de Identificación personal"
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("FeBaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id")
                        .HasName("PK__Usuarios__3214EC078BF374BA");

                    b.HasIndex("Role");

                    b.HasIndex("Usuario")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contrasena = "De1234567",
                            Role = 1,
                            Usuario = "Admin"
                        });
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Personas", b =>
                {
                    b.HasOne("OP.Prueba.Domain.Entities.Generos", "GeneroNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("Genero")
                        .IsRequired()
                        .HasConstraintName("FK_Persona_Genero");

                    b.HasOne("OP.Prueba.Domain.Entities.TiposDocumento", "TipoDocumentoNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("TipoDocumento")
                        .IsRequired()
                        .HasConstraintName("FK_Persona_TipoDocumento");

                    b.HasOne("OP.Prueba.Domain.Entities.Usuarios", "UsuarioNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("Usuario")
                        .HasConstraintName("FK_Persona_Usuario");

                    b.Navigation("GeneroNavigation");

                    b.Navigation("TipoDocumentoNavigation");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.ReservaPersonas", b =>
                {
                    b.HasOne("OP.Prueba.Domain.Entities.Personas", "PersonaNavigation")
                        .WithMany("ReservaPersonas")
                        .HasForeignKey("Persona")
                        .IsRequired()
                        .HasConstraintName("FK_ReservaPersona_Persona");

                    b.HasOne("OP.Prueba.Domain.Entities.Reservas", "ReservaNavigation")
                        .WithMany("ReservaPersonas")
                        .HasForeignKey("Reserva")
                        .IsRequired()
                        .HasConstraintName("FK_ReservaPersona_Reserva");

                    b.Navigation("PersonaNavigation");

                    b.Navigation("ReservaNavigation");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Reservas", b =>
                {
                    b.HasOne("OP.Prueba.Domain.Entities.ContactoEmergencia", "ContactoEmergenciaNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("ContactoEmergencia")
                        .HasConstraintName("FK_Reserva_ContactoEmergencia");

                    b.HasOne("OP.Prueba.Domain.Entities.Usuarios", "UsuarioNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("Usuario")
                        .IsRequired()
                        .HasConstraintName("FK_Reserva_Usuario");

                    b.Navigation("ContactoEmergenciaNavigation");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Usuarios", b =>
                {
                    b.HasOne("OP.Prueba.Domain.Entities.Roles", "RoleNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("Role")
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Role");

                    b.Navigation("RoleNavigation");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.ContactoEmergencia", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Generos", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Personas", b =>
                {
                    b.Navigation("ReservaPersonas");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Reservas", b =>
                {
                    b.Navigation("ReservaPersonas");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Roles", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.TiposDocumento", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("OP.Prueba.Domain.Entities.Usuarios", b =>
                {
                    b.Navigation("Personas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
