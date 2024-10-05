using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public class ApplicationContext : DbContext
//    {
        
//        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
//        {
        

//        }
//        public DbSet<Cliente> clientes { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder) 
//        {
//            modelBuilder.Entity<Cliente>();

//        }
//    }
//}

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Taller> Talleres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.Apellido)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.Contrasenia)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.NombreUser)
                      .IsRequired()
                      .HasMaxLength(50);


            });

            modelBuilder.Entity<Taller>(e =>
            {
                // Relacion entre taller - dueño 
                // un taller posee un dueño, e.HasOne(t => t.Dueño) e es entidad y t taller
                // un dueño puede tener varios talleres, .WithMany(d => d.Talleres) d es dueño
                e.HasOne(t => t.Dueño)
                 .WithMany(d => d.Talleres)
                 .HasForeignKey(t => t.DueñoId); 
            });
            
        }

    }
}
