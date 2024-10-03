using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
        }

    }
}
