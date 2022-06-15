using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.Property(c=>c.NumCuenta).IsRequired().HasMaxLength(10);
            builder.Property(c=>c.Tipo).IsRequired();
            builder.Property(c=>c.Saldo).HasColumnType("decimal(18,2)");
            // builder.HasOne(u=>u.Usuario).WithMany()
            //     .HasForeignKey(c=>c.UsuarioId);
        }
    }
}