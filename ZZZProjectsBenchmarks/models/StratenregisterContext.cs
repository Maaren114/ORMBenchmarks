using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tools;

namespace ZZZProjectsBenchmarks.models;

public partial class StratenregisterContext : DbContext
{
    public StratenregisterContext()
    {
    }

    public StratenregisterContext(DbContextOptions<StratenregisterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adres> Adressen { get; set; }

    public virtual DbSet<Gemeente> Gemeentes { get; set; }

    public virtual DbSet<Provincie> Provincies { get; set; }

    public virtual DbSet<Straat> Straten { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Toolkit.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.AdresId);

            entity.ToTable("Adressen");

            entity.Property(e => e.AdresId).HasColumnName("AdresID");
            entity.Property(e => e.Appartementnummer).HasMaxLength(80);
            entity.Property(e => e.Busnummer).HasMaxLength(80);
            entity.Property(e => e.Huisnummer).HasMaxLength(80);
            entity.Property(e => e.Niscode).HasColumnName("NISCode");
            entity.Property(e => e.Status).HasMaxLength(80);
            entity.Property(e => e.StraatId).HasColumnName("StraatID");

            entity.HasOne(d => d.Straat).WithMany(p => p.Adressen)
                .HasForeignKey(d => d.StraatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Straten_Adressen");
        });

        modelBuilder.Entity<Gemeente>(entity =>
        {
            entity.HasKey(e => e.GemeenteId).HasName("PK__Gemeente__3214EC2715E8C43A");

            entity.HasIndex(e => e.GemeenteId, "Unique_GemeenteID").IsUnique();

            entity.Property(e => e.GemeenteId).HasColumnName("GemeenteID");
            entity.Property(e => e.Gemeentenaam).HasMaxLength(40);
            entity.Property(e => e.ProvincieId).HasColumnName("ProvincieID");

            entity.HasOne(d => d.Provincie).WithMany(p => p.Gemeentes)
                .HasForeignKey(d => d.ProvincieId)
                .HasConstraintName("FK_Provincies_Gemeentes");
        });

        modelBuilder.Entity<Provincie>(entity =>
        {
            entity.HasKey(e => e.ProvincieId).HasName("PK__Provinci__F6C386943C77D1F2");

            entity.Property(e => e.ProvincieId).HasColumnName("ProvincieID");
            entity.Property(e => e.Provincienaam).HasMaxLength(80);
        });

        modelBuilder.Entity<Straat>(entity =>
        {
            entity.HasKey(e => e.StraatId).HasName("PK__StratenT__3214EC27D67C67E0");

            entity.ToTable("Straten");

            entity.HasIndex(e => e.StraatId, "UQ_StraatID").IsUnique();

            entity.Property(e => e.StraatId).HasColumnName("StraatID");
            entity.Property(e => e.GemeenteId).HasColumnName("GemeenteID");
            entity.Property(e => e.Straatnaam).HasMaxLength(80);

            entity.HasOne(d => d.Gemeente).WithMany(p => p.Straten)
                .HasForeignKey(d => d.GemeenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gemeentes_Straten");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
