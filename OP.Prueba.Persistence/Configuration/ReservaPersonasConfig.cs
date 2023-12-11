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
    public class ReservaPersonasConfig : IEntityTypeConfiguration<ReservaPersonas>
    {
        public void Configure(EntityTypeBuilder<ReservaPersonas> builder)
        {
            builder.ToTable("ReservaPersonas");

            builder.HasKey(e => e.Id).HasName("PK__ReservaPersonas__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Persona)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(e => e.Reserva)
                .IsRequired(true)
                .HasColumnType("int");

            builder.HasOne(d => d.PersonaNavigation).WithMany(p => p.ReservaPersonas)
                .HasForeignKey(d => d.Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPersona_Persona");

            builder.HasOne(d => d.ReservaNavigation).WithMany(p => p.ReservaPersonas)
                .HasForeignKey(d => d.Reserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPersona_Reserva");
        }
    }
}
