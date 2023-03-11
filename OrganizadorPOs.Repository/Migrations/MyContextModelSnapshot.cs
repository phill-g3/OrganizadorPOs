﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizadorPOs.Repository.Context;

#nullable disable

namespace OrganizadorPOs.Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrganizadorPOs.Domain.Entities.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EmitiuNotaFiscal")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FeitoEm")
                        .HasColumnType("datetime2");

                    b.Property<double>("HORAS")
                        .HasColumnType("float");

                    b.Property<string>("PO")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("PagamentoRecebido")
                        .HasColumnType("bit");

                    b.Property<string>("Projeto")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("RecebidaEm")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tipo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("ValorPO")
                        .HasColumnType("float");

                    b.Property<double>("WWC")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("OrganizadorPOs.Domain.Entities.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Tipos");
                });
#pragma warning restore 612, 618
        }
    }
}
