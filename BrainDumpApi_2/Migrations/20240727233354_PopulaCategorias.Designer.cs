﻿// <auto-generated />
using System;
using BrainDumpApi_2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrainDumpApi_2.Migrations
{
    [DbContext(typeof(BrainDumpApiContext))]
    [Migration("20240727233354_PopulaCategorias")]
    partial class PopulaCategorias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrainDumpApi_2.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BrainDumpApi_2.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("BrainDumpApi_2.Models.Nota", b =>
                {
                    b.HasOne("BrainDumpApi_2.Models.Categoria", "Categoria")
                        .WithMany("Notas")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("BrainDumpApi_2.Models.Categoria", b =>
                {
                    b.Navigation("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
