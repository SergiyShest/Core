using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public partial class KorfinContext : DbContext
{
    public KorfinContext()
    {
    }

    public KorfinContext(DbContextOptions<KorfinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ost> Osts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


    {
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var connect = config.GetConnectionString("WebApiDatabase");
        optionsBuilder.UseNpgsql(connect);
        optionsBuilder.LogTo(message=> Debug.WriteLine(message));
        //optionsBuilder.EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Osts_pkey");
            entity.ToTable("Osts", "korfin");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.ToTable("Users", "korfin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(1);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
