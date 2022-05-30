﻿// <auto-generated />
using System;
using MicroservicioMovimientos.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroservicioMovimientos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220529221728_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicroservicioMovimientos.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("personaId");

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Cuenta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldoInicial")
                        .HasColumnType("float");

                    b.Property<string>("tipoCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.ToTable("tb_cuenta");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Movimiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.Property<string>("tipoMovimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("cuentaId");

                    b.ToTable("tb_movimiento");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tb_persona");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Cliente", b =>
                {
                    b.HasOne("MicroservicioMovimientos.Models.Persona", "personas")
                        .WithMany()
                        .HasForeignKey("personaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personas");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Cuenta", b =>
                {
                    b.HasOne("MicroservicioMovimientos.Models.Cliente", "clientes")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clientes");
                });

            modelBuilder.Entity("MicroservicioMovimientos.Models.Movimiento", b =>
                {
                    b.HasOne("MicroservicioMovimientos.Models.Cuenta", "cuentas")
                        .WithMany()
                        .HasForeignKey("cuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}