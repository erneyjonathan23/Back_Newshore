using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.Prueba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Persistence.Configuration
{
    public class ReservasConfig : IEntityTypeConfiguration<Reservas>
    {
        public void Configure(EntityTypeBuilder<Reservas> builder)
        {
            builder.ToTable("Reservas");

            builder.HasKey(e => e.Id).HasName("PK__Reservas__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Usuario)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.Estado)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.TipoViaje)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.Origen)
                .IsRequired(true)
                .HasColumnType("varchar")
                .HasMaxLength(3);

            builder.Property(e => e.Destino)
                .IsRequired(true)
                .HasColumnType("varchar")
                .HasMaxLength(3);

            builder.Property(e => e.FechaInicio)
                .IsRequired(true)
                .HasColumnType("datetime");

            builder.Property(e => e.FechaFin)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.Property(e => e.ContactoEmergencia)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.NumeroPersonas)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.Precio)
                .IsRequired(true)
                .HasColumnType("float");

            builder.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Usuario");

            builder.HasOne(d => d.ContactoEmergenciaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ContactoEmergencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_ContactoEmergencia");
        }
    }
}
