﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StoreEP.Models;
using System;

namespace StoreEP.Migrations
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

                    b.Property<int?>("PedidoId");

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("CartLineID");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("StoreEP.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<byte>("Estrela");

                    b.Property<string>("NomeUsuario");

                    b.Property<int?>("ProdutoId");

                    b.Property<string>("Texto");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("StoreEP.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<bool>("GifWrap");

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("StoreEP.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<string>("Nome");

                    b.Property<int>("ProdutoId");

                    b.HasKey("ImagemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("StoreEP.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompraDT");

                    b.Property<DateTime?>("PagamentoDT");

                    b.Property<int>("PedidoId");

                    b.Property<string>("UserId");

                    b.Property<decimal>("Valor");

                    b.HasKey("PagamentoId");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("StoreEP.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCompra");

                    b.Property<int?>("EnderecoId");

                    b.Property<bool>("Shipped");

                    b.Property<string>("UserId");

                    b.HasKey("PedidoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("StoreEP.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Fabricante");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("StoreEP.Models.CartLine", b =>
                {
                    b.HasOne("StoreEP.Models.Pedido")
                        .WithMany("Lines")
                        .HasForeignKey("PedidoId");

                    b.HasOne("StoreEP.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("StoreEP.Models.Comentario", b =>
                {
                    b.HasOne("StoreEP.Models.Produto")
                        .WithMany("Comentarios")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("StoreEP.Models.Imagem", b =>
                {
                    b.HasOne("StoreEP.Models.Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreEP.Models.Pagamento", b =>
                {
                    b.HasOne("StoreEP.Models.Pedido")
                        .WithOne("Pagamento")
                        .HasForeignKey("StoreEP.Models.Pagamento", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreEP.Models.Pedido", b =>
                {
                    b.HasOne("StoreEP.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });
#pragma warning restore 612, 618
        }
    }
}
