using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u=>u.Cedula).IsRequired().HasMaxLength(10);
            builder.Property(u=>u.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(u=>u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u=>u.FechaNacimiento).IsRequired();
            builder.Property(u=>u.Clave).IsRequired().HasMaxLength(8);

        }
    }
}