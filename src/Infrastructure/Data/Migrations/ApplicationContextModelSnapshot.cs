﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Entities.Bicicleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Bicicletas");
                });

            modelBuilder.Entity("Domain.Entities.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BicicletaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TallerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("estadoMantenimiento")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BicicletaId");

                    b.HasIndex("TallerId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("Domain.Entities.Taller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DuenoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DuenoId");

                    b.ToTable("Talleres");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUser")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserRole")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator<int>("UserRole");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Domain.Entities.Dueno", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.Entities.SysAdmin", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.Entities.Bicicleta", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Bicicletas")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Mantenimiento", b =>
                {
                    b.HasOne("Domain.Entities.Bicicleta", "Bicicleta")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("BicicletaId");

                    b.HasOne("Domain.Entities.Taller", "Taller")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("TallerId");

                    b.Navigation("Bicicleta");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("Domain.Entities.Taller", b =>
                {
                    b.HasOne("Domain.Entities.Dueno", "Dueno")
                        .WithMany("Talleres")
                        .HasForeignKey("DuenoId");

                    b.Navigation("Dueno");
                });

            modelBuilder.Entity("Domain.Entities.Bicicleta", b =>
                {
                    b.Navigation("Mantenimientos");
                });

            modelBuilder.Entity("Domain.Entities.Taller", b =>
                {
                    b.Navigation("Mantenimientos");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Bicicletas");
                });

            modelBuilder.Entity("Domain.Entities.Dueno", b =>
                {
                    b.Navigation("Talleres");
                });
#pragma warning restore 612, 618
        }
    }
}
