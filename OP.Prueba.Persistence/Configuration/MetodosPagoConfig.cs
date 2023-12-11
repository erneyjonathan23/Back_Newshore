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
    public class MetodosPagoConfig : IEntityTypeConfiguration<MetodosPago>
    {
        public void Configure(EntityTypeBuilder<MetodosPago> builder)
        {
            builder.ToTable("MetodosPago");

            builder.HasKey(e => e.Id).HasName("PK__MetodosPago__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.MetodoPago)
                .HasMaxLength(150)
                .IsRequired(true)
                .HasColumnType("varchar");
        }
    }
}
