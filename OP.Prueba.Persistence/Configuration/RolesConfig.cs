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
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(e => e.Id).HasName("PK__Roles__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Role)
                .HasMaxLength(150)
                .IsRequired(true)
                .HasColumnType("varchar");

            builder.Property(e => e.Nivel)
                .IsRequired(false)
                .HasColumnType("int");
        }
    }
}
