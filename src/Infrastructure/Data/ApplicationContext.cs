using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);  

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Mensajes)  
                .WithOne(m => m.Cliente)
                .HasForeignKey(m => m.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Bicicletas)  
                .WithOne(b => b.Cliente)
                .HasForeignKey(b => b.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mensaje>()
        .Property(m => m.EstadoMensaje)
        .HasConversion(
            v => v.ToString(),
            v => (EstadoMensaje)Enum.Parse(typeof(EstadoMensaje), v));

            modelBuilder.Entity<Mensaje>()
                .HasKey(m => m.Id);  

              

            modelBuilder.Entity<Bicicleta>()
                .HasKey(b => b.Id);  

            modelBuilder.Entity<Bicicleta>()
                .Property(b => b.Marca)
                .IsRequired()
                .HasMaxLength(100);  

            modelBuilder.Entity<Bicicleta>()
                .Property(b => b.Modelo)
                .IsRequired()
                .HasMaxLength(100);  
        }
    }
}
