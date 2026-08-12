using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RedeAurora.Domains;

namespace RedeAurora.Contexts;

public partial class RedeAuroraContext : DbContext
{
    public RedeAuroraContext()
    {
    }

    public RedeAuroraContext(DbContextOptions<RedeAuroraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemInventario> ItemInventario { get; set; }

    public virtual DbSet<Setor> Setor { get; set; }

    public virtual DbSet<Unidade> Unidade { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RedeAurora;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemInventario>(entity =>
        {
            entity.HasKey(e => e.id_item).HasName("PK__ItemInve__87C9438BB94CF694");

            entity.HasIndex(e => e.codigo_patrimonio, "UQ__ItemInve__6FB408FA5351DEAB").IsUnique();

            entity.Property(e => e.codigo_patrimonio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.condicao)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.data_hora).HasColumnType("datetime");
            entity.Property(e => e.descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.nome)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.id_setorNavigation).WithMany(p => p.ItemInventario)
                .HasForeignKey(d => d.id_setor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_iteminventario_setor");

            entity.HasOne(d => d.id_usuarioNavigation).WithMany(p => p.ItemInventario)
                .HasForeignKey(d => d.id_usuario)
                .HasConstraintName("fk_item_Usuario");
        });

        modelBuilder.Entity<Setor>(entity =>
        {
            entity.HasKey(e => e.id_setor).HasName("PK__Setor__4861BDD4E40BBF17");

            entity.HasIndex(e => e.nome, "UQ__Setor__6F71C0DCEA5DD75A").IsUnique();

            entity.Property(e => e.nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.id_unidadeNavigation).WithMany(p => p.Setor)
                .HasForeignKey(d => d.id_unidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Setor_unidade");
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.id_unidade).HasName("PK__Unidade__0B6FAEC4B4987E5D");

            entity.HasIndex(e => e.nome, "UQ__Unidade__6F71C0DC1E69D8AC").IsUnique();

            entity.Property(e => e.nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.id_usuario).HasName("PK__Usuario__4E3E04AD3BFBE954");

            entity.Property(e => e.id_usuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
