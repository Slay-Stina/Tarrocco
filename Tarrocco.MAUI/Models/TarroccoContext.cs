using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tarrocco.MAUI.Models;

public partial class TarroccoContext : DbContext
{
    private static string ParentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    private static string DatabasePath = Path.Combine(ParentPath, "Data", "tarrocco.db");

    public TarroccoContext()
    {
    }

    public TarroccoContext(DbContextOptions<TarroccoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DatabasePath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
