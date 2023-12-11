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
    public class ContactoEmergenciaConfig : IEntityTypeConfiguration<ContactoEmergencia>
    {
        public void Configure(EntityTypeBuilder<ContactoEmergencia> builder)
        {
            builder.ToTable("ContactoEmergencia");

            builder.HasKey(e => e.Id).HasName("PK__ContactoEmergencia__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsRequired(true)
                .HasColumnType("varchar");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsRequired(true)
                .HasColumnType("varchar");

            builder.Property(e => e.NumeroContacto)
                .IsRequired(true)
                .HasColumnType("bigint");

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsRequired(false)
                .HasColumnType("varchar");
        }
    }
}
