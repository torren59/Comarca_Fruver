﻿// <auto-generated />
using Comarca_Fruver.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comarca_Fruver.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220526020626_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Comarca_Fruver.Models.Cargamento", b =>
                {
                    b.Property<int>("IdCargamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCargamento"), 1L, 1);

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("int");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCargamento");

                    b.ToTable("cargamentos");
                });

            modelBuilder.Entity("Comarca_Fruver.Models.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolID"), 1L, 1);

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolID");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Comarca_Fruver.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
