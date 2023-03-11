﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizadorPOs.Repository.Context;

#nullable disable

namespace OrganizadorPOs.Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230309015028_InitialD")]
    partial class InitialD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("EmitiuNotaFiscal")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FeitoEm")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HORAS")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPO")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WWC")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}