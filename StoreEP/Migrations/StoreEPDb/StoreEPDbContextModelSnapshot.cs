﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StoreEP.Models;
using System;

namespace StoreEP.Migrations.StoreEPDb
{
    [DbContext(typeof(StoreEPDbContext))]
    partial class StoreEPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreEP.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PedidoID");

                    b.Property<int?>("ProdutoID");

                    b.Property<int>("Quantidade");

                    b.HasKey("CartLineID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("StoreEP.Models.Comentario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<byte>("Estrela");

                    b.Property<string>("NomeUsuario");

                    b.Property<int>("ProdutoID");

                    b.Property<string>("Texto");

                    b.HasKey("ID");

                    b.HasIndex("ProdutoID")
                        .IsUnique();

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("StoreEP.Models.Endereco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<bool>("GifWrap");

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("StoreEP.Models.Imagem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LinkImagem");

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("StoreEP.Models.Pagamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompraDT");

                    b.Property<DateTime>("PagamentoDT");

                    b.Property<int>("PedidoID");

                    b.Property<string>("UserID");

                    b.Property<decimal>("Valor");

                    b.HasKey("ID");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("StoreEP.Models.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressID");

                    b.Property<bool>("Shipped");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("StoreEP.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoriaPD")
                        .IsRequired();

                    b.Property<string>("DescricaoPD")
                        .IsRequired();

                    b.Property<string>("Fabricante");

                    b.Property<int?>("ImagemID");

                    b.Property<string>("NomePD")
                        .IsRequired();

                    b.Property<decimal>("PrecoPD");

                    b.HasKey("ProdutoID");

                    b.HasIndex("ImagemID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("StoreEP.Models.CartLine", b =>
                {
                    b.HasOne("StoreEP.Models.Pedido")
                        .WithMany("Lines")
                        .HasForeignKey("PedidoID");

                    b.HasOne("StoreEP.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");
                });

            modelBuilder.Entity("StoreEP.Models.Comentario", b =>
                {
                    b.HasOne("StoreEP.Models.Produto")
                        .WithOne("Comentario")
                        .HasForeignKey("StoreEP.Models.Comentario", "ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreEP.Models.Pedido", b =>
                {
                    b.HasOne("StoreEP.Models.Endereco", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");
                });

            modelBuilder.Entity("StoreEP.Models.Produto", b =>
                {
                    b.HasOne("StoreEP.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemID");
                });
#pragma warning restore 612, 618
        }
    }
}
