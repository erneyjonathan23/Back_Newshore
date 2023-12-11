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
    public class TiposDocumentoConfig : IEntityTypeConfiguration<TiposDocumento>
    {
        public void Configure(EntityTypeBuilder<TiposDocumento> builder)
        {
            builder.ToTable("TiposDocumento");

            builder.HasKey(e => e.Id).HasName("PK__TiposDocumento__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsRequired(true)
                .HasColumnType("varchar");

            builder.Property(e => e.TipoDocumento)
                .HasMaxLength(150)
                .IsRequired(true)
                .HasColumnType("varchar");
        }
    }
}
