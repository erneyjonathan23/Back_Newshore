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
    public class UsuariosConfig : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC078BF374BA");

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Usuario)
                .IsRequired(true)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.HasIndex(e => e.Usuario)
                .IsUnique(true);

            builder.Property(e => e.Contrasena)
                .IsRequired(true)
                .HasMaxLength(500)
                .HasColumnType("varchar");

            builder.Property(e => e.Role)
                .IsRequired(true)
                .HasColumnType("int");

            builder.HasOne(d => d.RoleNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Role");
        }
    }
}
