﻿// <auto-generated />
using System;
using CamposDealer.API.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CamposDealer.API.Migrations
{
    [DbContext(typeof(MicrosoftSQLContext))]
    [Migration("20220612061451_FixingErrorYO")]
    partial class FixingErrorYO
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CamposDealer.API.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<string>("NmCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NmCliente");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CamposDealer.API.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 1L, 1);

                    b.Property<string>("DscProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<double>("VlrUnitario")
                        .HasColumnType("float")
                        .HasColumnName("ValorUnitario");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("CamposDealer.API.Models.Vendas", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenda"), 1L, 1);

                    b.Property<DateTime>("DthVenda")
                        .HasColumnType("datetime2")
                        .HasColumnName("DthVenda");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("QtdVenda")
                        .HasColumnType("int")
                        .HasColumnName("QtdVenda");

                    b.Property<double>("VlrTotalVenda")
                        .HasColumnType("float")
                        .HasColumnName("VlrTotalVenda");

                    b.Property<double>("VlrUnitarioVenda")
                        .HasColumnType("float")
                        .HasColumnName("VlrUnitarioVenda");

                    b.HasKey("IdVenda");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
