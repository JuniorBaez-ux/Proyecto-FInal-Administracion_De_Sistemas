﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_FInal_Administracion_De_Sistemas.DAL;

namespace Proyecto_FInal_Administracion_De_Sistemas.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<int>("CondominioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CondominiosCondominioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Referencia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.HasIndex("CondominiosCondominioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Condominios", b =>
                {
                    b.Property<int>("CondominioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoCondominiosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CondominioId");

                    b.HasIndex("TipoCondominiosId");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Recibos", b =>
                {
                    b.Property<int>("ReciboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientesClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CondominioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CondominiosCondominioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReciboId");

                    b.HasIndex("ClientesClienteId");

                    b.HasIndex("CondominiosCondominioId");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.TipoCondominios", b =>
                {
                    b.Property<int>("TipoCondominioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoCondominioId");

                    b.ToTable("TipoCondominios");

                    b.HasData(
                        new
                        {
                            TipoCondominioId = 1,
                            Tipo = "Apartamento"
                        },
                        new
                        {
                            TipoCondominioId = 2,
                            Tipo = "Parqueo"
                        });
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Clientes", b =>
                {
                    b.HasOne("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Condominios", "Condominios")
                        .WithMany()
                        .HasForeignKey("CondominiosCondominioId");

                    b.Navigation("Condominios");
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Condominios", b =>
                {
                    b.HasOne("Proyecto_FInal_Administracion_De_Sistemas.Entidades.TipoCondominios", "TipoCondominios")
                        .WithMany()
                        .HasForeignKey("TipoCondominiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCondominios");
                });

            modelBuilder.Entity("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Recibos", b =>
                {
                    b.HasOne("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesClienteId");

                    b.HasOne("Proyecto_FInal_Administracion_De_Sistemas.Entidades.Condominios", "Condominios")
                        .WithMany()
                        .HasForeignKey("CondominiosCondominioId");

                    b.Navigation("Clientes");

                    b.Navigation("Condominios");
                });
#pragma warning restore 612, 618
        }
    }
}
