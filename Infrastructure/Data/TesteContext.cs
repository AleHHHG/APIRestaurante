using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public class TesteContext : DbContext
    {

        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Restaurante>(ConfigureRestaurante);
            builder.Entity<Prato>(ConfigurePrato);
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("restaurantes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Nome)
                .IsRequired(true)
                .HasMaxLength(200);

        }

        private void ConfigurePrato(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("pratos");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Nome)
               .IsRequired(true)
               .HasMaxLength(200);

            builder.HasOne(ci => ci.Restaurante)
               .WithMany()
               .HasForeignKey(ci => ci.RestauranteId);

        }
    }
}
