using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartSmoker19.Server.Models.AltDbContext;

public partial class AltAppDbContext : DbContext
{
    public AltAppDbContext()
    {
    }

    public AltAppDbContext(DbContextOptions<AltAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<currentstate> currentstate { get; set; }

    public virtual DbSet<desiredstate> desiredstate { get; set; }

    public virtual DbSet<meatsmokingguide> meatsmokingguide { get; set; }

    public virtual DbSet<meatwood> meatwood { get; set; }

    public virtual DbSet<recommendedwood> recommendedwood { get; set; }

    public virtual DbSet<thermcam> thermcam { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<currentstate>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_currentstate");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.modified).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<desiredstate>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_desiredstate");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.modified).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<meatsmokingguide>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_meatsmokingguide");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.approxtime).HasMaxLength(450);
            entity.Property(e => e.approxtime2).HasMaxLength(450);
            entity.Property(e => e.meatcut).HasMaxLength(450);
            entity.Property(e => e.meattype).HasMaxLength(450);
        });

        modelBuilder.Entity<meatwood>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("meatwood");

            entity.Property(e => e.approxtime).HasMaxLength(450);
            entity.Property(e => e.approxtime2).HasMaxLength(450);
            entity.Property(e => e.meatcut).HasMaxLength(450);
            entity.Property(e => e.meattype).HasMaxLength(450);
            entity.Property(e => e.wood0).HasMaxLength(450);
            entity.Property(e => e.wood1).HasMaxLength(450);
            entity.Property(e => e.wood2).HasMaxLength(450);
            entity.Property(e => e.wood3).HasMaxLength(450);
            entity.Property(e => e.wood4).HasMaxLength(450);
        });

        modelBuilder.Entity<recommendedwood>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_recommendedwood");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.meattype).HasMaxLength(450);
            entity.Property(e => e.wood0).HasMaxLength(450);
            entity.Property(e => e.wood1).HasMaxLength(450);
            entity.Property(e => e.wood2).HasMaxLength(450);
            entity.Property(e => e.wood3).HasMaxLength(450);
            entity.Property(e => e.wood4).HasMaxLength(450);
        });

        modelBuilder.Entity<thermcam>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_thermcam");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.modified).HasDefaultValueSql("now()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
