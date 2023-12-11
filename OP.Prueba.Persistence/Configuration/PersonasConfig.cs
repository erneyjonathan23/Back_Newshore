using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Persistence.Configuration
{
    public class PersonasConfig : IEntityTypeConfiguration<Personas>
    {
        public void Configure(EntityTypeBuilder<Personas> builder)
        {
            builder.ToTable("Personas");

            builder.HasKey(e => e.Id).HasName("PK__Personas__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Nombres)
                .IsRequired(true)
                .HasMaxLength(120)
                .HasColumnType("varchar");

            builder.Property(e => e.Apellidos)
                .IsRequired(true)
                .HasMaxLength(120)
                .HasColumnType("varchar");

            builder.Property(e => e.FechaNacimiento)
                .IsRequired(true)
                .HasColumnType("datetime");

            builder.Property(e => e.Genero)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.TipoDocumento)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.NumeroDocumento)
                .IsRequired(true)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.HasIndex(p => p.NumeroDocumento);

            builder.Property(e => e.Email)
                .IsRequired(true)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.Property(e => e.TelefonoContacto)
                .IsRequired(true)
                .HasColumnType("bigint");

            builder.Property(e => e.Usuario)
                .IsRequired(false)
                .HasColumnType("int");

            builder.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Usuario");

            builder.HasOne(d => d.GeneroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Genero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Genero");

            builder.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Persona_TipoDocumento");
        }
    }
}
