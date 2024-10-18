using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Dueño> Dueños { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Tabla Clientes");
            modelBuilder.Entity<Dueño>().ToTable("Tabla Dueños");

            modelBuilder.Entity<Taller>(e =>
            {
                // Relacion entre taller - dueño 
                // un taller posee un dueño, e.HasOne(t => t.Dueño) e es entidad y t taller
                // un dueño puede tener varios talleres, .WithMany(d => d.Talleres) d es dueño
                e.HasOne(t => t.Dueño)
                 .WithMany(d => d.Talleres)
                 .HasForeignKey(t => t.DueñoId); 
            });

            modelBuilder.Entity<Bicicleta>(e =>
            {
                // Relacion entre bicicleta - cliente 
                // una bicicleta posee un cliente, e.HasOne(b => b.Cliente) e es entidad y b bicicleta
                // un cliente puede tener varias bicilcetas, .WithMany(c => c.Bicicletas) c es cliente
                e.HasOne(b => b.Cliente)
                 .WithMany(c => c.Bicicletas)
                 .HasForeignKey(b => b.ClienteId);
                 
            });

            modelBuilder.Entity<Dueño>(e =>
            {
                e.HasMany(d => d.Talleres)
                .WithOne(t => t.Dueño)
                .HasForeignKey(t => t.DueñoId);
            });

            modelBuilder.Entity<Cliente>(e =>
            {
                e.HasMany(d => d.Bicicletas)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId);
            });

            base.OnModelCreating(modelBuilder);

            
        }

    }
}
