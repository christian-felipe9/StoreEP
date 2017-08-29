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
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170829171214_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreEP.Produto", b =>
                {
                    b.Property<int>("CD_Produto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImagemProduto");

                    b.Property<string>("NM_Categoria");

                    b.Property<string>("NM_Produto");

                    b.Property<string>("PD_Descricao");

                    b.Property<string>("PD_Fabricante");

                    b.Property<int?>("PD_RelacionadoCD_Produto");

                    b.Property<decimal>("Preco");

                    b.HasKey("CD_Produto");

                    b.HasIndex("PD_RelacionadoCD_Produto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("StoreEP.Produto", b =>
                {
                    b.HasOne("StoreEP.Produto", "PD_Relacionado")
                        .WithMany()
                        .HasForeignKey("PD_RelacionadoCD_Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
