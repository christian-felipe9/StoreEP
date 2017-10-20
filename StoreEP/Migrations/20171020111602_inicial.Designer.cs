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
    [Migration("20171020111602_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("ComentarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Aprovado");

                    b.Property<string>("Assunto");

                    b.Property<int?>("ComentarioID1");

                    b.Property<DateTime>("Data");

                    b.Property<byte>("Estrela");

                    b.Property<string>("NomeUsuario");

                    b.Property<int>("ProdutoID");

                    b.Property<string>("Texto");

                    b.Property<string>("UsuarioID");

                    b.HasKey("ComentarioID");

                    b.HasIndex("ComentarioID1");

                    b.HasIndex("ProdutoID");

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

                    b.Property<DateTime>("Utilizado");

                    b.HasKey("ID");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("StoreEP.Models.HistoricoPreco", b =>
                {
                    b.Property<int>("PrecoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAltarecao");

                    b.Property<int>("ID");

                    b.Property<decimal>("PrecoAntigo");

                    b.Property<decimal>("PrecoNovo");

                    b.HasKey("PrecoId");

                    b.ToTable("HistoricoPreco");
                });

            modelBuilder.Entity("StoreEP.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("ProdutoID");

                    b.HasKey("ImagemID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("StoreEP.Models.Pagamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompraDT");

                    b.Property<DateTime?>("PagamentoDT");

                    b.Property<int>("PedidoId");

                    b.Property<string>("UserId");

                    b.Property<decimal>("Valor");

                    b.HasKey("ID");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("StoreEP.Models.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCompra");

                    b.Property<int?>("EnderecoID");

                    b.Property<bool>("Shipped");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("EnderecoID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("StoreEP.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Fabricante");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.Property<bool>("Publicado");

                    b.Property<int>("Quantidade");

                    b.HasKey("ProdutoID");

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
                    b.HasOne("StoreEP.Models.Comentario")
                        .WithMany("Respostas")
                        .HasForeignKey("ComentarioID1");

                    b.HasOne("StoreEP.Models.Produto")
                        .WithMany("Comentarios")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreEP.Models.Imagem", b =>
                {
                    b.HasOne("StoreEP.Models.Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("ProdutoID")
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
                        .HasForeignKey("EnderecoID");
                });
#pragma warning restore 612, 618
        }
    }
}
