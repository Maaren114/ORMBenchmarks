using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tools;

namespace EFCoreBenchmarks.models;

public partial class StratenregisterContext : DbContext
{
    public StratenregisterContext()
    {

    }

    public StratenregisterContext(DbContextOptions<StratenregisterContext> options) : base(options)
    {

    }

    public virtual DbSet<AdresX> Adressen { get; set; }

    public virtual DbSet<GemeenteX> Gemeentes { get; set; }

    public virtual DbSet<ProvincieX> Provincies { get; set; }

    public virtual DbSet<StraatX> Straten { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Toolkit.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdresX>(entity =>
        {
            entity.HasKey(e => e.AdresID);

            entity.ToTable("Adressen");

            entity.Property(e => e.AdresID).HasColumnName("AdresID");
            entity.Property(e => e.Appartementnummer).HasMaxLength(80);
            entity.Property(e => e.Busnummer).HasMaxLength(80);
            entity.Property(e => e.Huisnummer).HasMaxLength(80);
            entity.Property(e => e.NISCode).HasColumnName("NISCode");
            entity.Property(e => e.Status).HasMaxLength(80);
            entity.Property(e => e.StraatID).HasColumnName("StraatID");

            entity.HasOne(d => d.Straat).WithMany(p => p.Adressen)
                .HasForeignKey(d => d.StraatID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Straten_Adressen");
        });

        modelBuilder.Entity<GemeenteX>(entity =>
        {
            entity.HasKey(e => e.GemeenteID).HasName("PK__Gemeente__3214EC2715E8C43A");

            entity.HasIndex(e => e.GemeenteID, "Unique_GemeenteID").IsUnique();

            entity.Property(e => e.GemeenteID).HasColumnName("GemeenteID");
            entity.Property(e => e.Gemeentenaam).HasMaxLength(40);
            entity.Property(e => e.ProvincieID).HasColumnName("ProvincieID");

            entity.HasOne(d => d.Provincie).WithMany(p => p.Gemeentes)
                .HasForeignKey(d => d.ProvincieID)
                .HasConstraintName("FK_Provincies_Gemeentes");
        });

        modelBuilder.Entity<ProvincieX>(entity =>
        {
            entity.HasKey(e => e.ProvincieID).HasName("PK__Provinci__F6C386943C77D1F2");

            entity.Property(e => e.ProvincieID).HasColumnName("ProvincieID");
            entity.Property(e => e.Provincienaam).HasMaxLength(80);
        });

        modelBuilder.Entity<StraatX>(entity =>
        {
            entity.HasKey(e => e.StraatID).HasName("PK__StratenT__3214EC27D67C67E0");

            entity.ToTable("Straten");

            entity.HasIndex(e => e.StraatID, "UQ_StraatID").IsUnique();

            entity.Property(e => e.StraatID).HasColumnName("StraatID");
            entity.Property(e => e.GemeenteID).HasColumnName("GemeenteID");
            entity.Property(e => e.Straatnaam).HasMaxLength(80);

            entity.HasOne(d => d.Gemeente).WithMany(p => p.Straten)
                .HasForeignKey(d => d.GemeenteID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gemeentes_Straten");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
