using Domain.Entities;
using Domain.Enums;
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
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Dueno> Duenos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Cliente>().ToTable("Tabla Clientes");
            //modelBuilder.Entity<Dueno>().ToTable("Tabla Duenos");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")  // Mapea toda la jerarquía a la misma tabla "Usuarios"
                .HasDiscriminator<UserRole>("UserRole")
                .HasValue<Cliente>(UserRole.Cliente)
                .HasValue<Dueno>(UserRole.Dueno)
                .HasValue<SysAdmin>(UserRole.SysAdmin);

            modelBuilder.Entity<Taller>(e =>
            {
                // Relacion entre taller - Dueno 
                // un taller posee un Dueno, e.HasOne(t => t.Dueno) e es entidad y t taller
                // un Dueno puede tener varios talleres, .WithMany(d => d.Talleres) d es Dueno
                e.HasOne(t => t.Dueno)
                 .WithMany(d => d.Talleres)
                 .HasForeignKey(t => t.DuenoId); 
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

            modelBuilder.Entity<Mantenimiento>(m =>
            {
                m.HasOne(m => m.Taller)
                .WithMany(t => t.Mantenimientos)
                .HasForeignKey(m => m.TallerId);
            });

            modelBuilder.Entity<Mantenimiento>(m =>
            {
                m.HasOne(m => m.Bicicleta)
                .WithMany(b => b.Mantenimientos)
                .HasForeignKey(m => m.BicicletaId);
            });

            modelBuilder.Entity<Dueno>(e =>
            {
                e.HasMany(d => d.Talleres)
                .WithOne(t => t.Dueno)
                .HasForeignKey(t => t.DuenoId);
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
