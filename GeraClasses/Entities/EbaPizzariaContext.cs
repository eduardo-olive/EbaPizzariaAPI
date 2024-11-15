using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.Domain.Entities;

public partial class EbaPizzariaContext : DbContext
{
    public EbaPizzariaContext()
    {
    }

    public EbaPizzariaContext(DbContextOptions<EbaPizzariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-79GUGQ6;Database=EbaPizzaria;User Id=sa;Password=masterkey;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Contato)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasMany(d => d.IdPizzas).WithMany(p => p.IdIngredientes)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientesPizza",
                    r => r.HasOne<Pizza>().WithMany()
                        .HasForeignKey("IdPizza")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IngredientesPizza_Pizza"),
                    l => l.HasOne<Ingrediente>().WithMany()
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IngredientesPizza_Ingredientes"),
                    j =>
                    {
                        j.HasKey("IdIngrediente", "IdPizza").HasName("FK_INGREDIENTES_PIZZA");
                        j.ToTable("IngredientesPizza");
                    });
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdPizza }).HasName("FK_PEDIDO_PIZZA");

            entity.ToTable("ItensPedido");

            entity.Property(e => e.ValorTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensPedido_Pedido");

            entity.HasOne(d => d.IdPizzaNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.IdPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensPedido_Pizza");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Pedido");

            entity.Property(e => e.DataPedido).HasColumnType("datetime");
            entity.Property(e => e.ValorPedido).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Cliente");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.ToTable("Pizza");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(4, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
