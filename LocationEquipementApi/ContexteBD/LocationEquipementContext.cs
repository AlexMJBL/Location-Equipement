using System;
using System.Collections.Generic;
using LocationEquipementApi.Entites;
using Microsoft.EntityFrameworkCore;

namespace LocationEquipementApi.ContexteBD;

public partial class LocationEquipementContext : DbContext
{
    public LocationEquipementContext()
    {
    }

    public LocationEquipementContext(DbContextOptions<LocationEquipementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipement> Equipements { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=BD/LocationEquipement.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipement>(entity =>
        {
            entity.ToTable("Equipement");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.HasOne(d => d.Equipement).WithMany(p => p.Locations)
                .HasForeignKey(d => d.EquipementId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.Property(e => e.DateDe)
            .HasConversion(
                v => v.ToString("yyyy-MM-dd"),  
                v => DateOnly.Parse(v)          
            );

            entity.Property(e => e.DateA)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd"),
                    v => DateOnly.Parse(v)
                );

            entity.Property(e => e.Active)
                .HasConversion<int>();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
