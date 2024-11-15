﻿// <auto-generated />
using System;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EbaPizzaria.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.IngredientesPizza", b =>
                {
                    b.Property<int>("IdPizza")
                        .HasColumnType("int");

                    b.Property<int>("IdIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("IngredientesId")
                        .HasColumnType("int");

                    b.Property<int>("PizzasId")
                        .HasColumnType("int");

                    b.HasKey("IdPizza", "IdIngrediente");

                    b.HasIndex("IngredientesId");

                    b.HasIndex("PizzasId");

                    b.ToTable("IngredientesPizza");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.ItensPedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdPizza")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido", "IdPizza");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("ItensPedidoIdPedido")
                        .HasColumnType("int");

                    b.Property<int?>("ItensPedidoIdPizza")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPedido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("ItensPedidoIdPedido", "ItensPedidoIdPizza");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ItensPedidoIdPedido")
                        .HasColumnType("int");

                    b.Property<int?>("ItensPedidoIdPizza")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ItensPedidoIdPedido", "ItensPedidoIdPizza");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.IngredientesPizza", b =>
                {
                    b.HasOne("EbaPizzaria.Domain.Entities.Ingrediente", "Ingredientes")
                        .WithMany("Ingredirntes")
                        .HasForeignKey("IngredientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbaPizzaria.Domain.Entities.Pizza", "Pizzas")
                        .WithMany("IngredientesPizza")
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredientes");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("EbaPizzaria.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EbaPizzaria.Domain.Entities.ItensPedido", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ItensPedidoIdPedido", "ItensPedidoIdPizza");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Pizza", b =>
                {
                    b.HasOne("EbaPizzaria.Domain.Entities.ItensPedido", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("ItensPedidoIdPedido", "ItensPedidoIdPizza");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Ingrediente", b =>
                {
                    b.Navigation("Ingredirntes");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.ItensPedido", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("EbaPizzaria.Domain.Entities.Pizza", b =>
                {
                    b.Navigation("IngredientesPizza");
                });
#pragma warning restore 612, 618
        }
    }
}
