using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeCadastroAPI.Models;

namespace SistemaDeCadastroAPI.Data
{
    public partial class DB_testeContext : DbContext
    {
        public DB_testeContext()
        {
        }

        public DB_testeContext(DbContextOptions<DB_testeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteModel> Clientes { get; set; } = null!;
        public virtual DbSet<PedidoModel> Pedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-J2GC2AR;Database=DB_teste;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_Cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idCliente");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Senha)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PedidoModel>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.Property(e => e.IdPedido)
                    .ValueGeneratedNever()
                    .HasColumnName("idPedido");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Pedido)
                    .HasMaxLength(10)
                    .HasColumnName("Pedido")
                    .IsFixedLength();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
