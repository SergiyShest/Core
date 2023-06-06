using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KORFIN;Username=user;Password=Adm");
        optionsBuilder.LogTo(message=> Debug.WriteLine(message));
        optionsBuilder.EnableDetailedErrors();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("osts_pkey");

            entity.ToTable("osts", "korfin");

            entity.Property(e => e.Id).HasIdentityOptions(null, null, 0L, 10000000L, null, null);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdOst).HasName("Users_pkey");

            entity.ToTable("Users", "korfin");

            entity.HasIndex(e => e.Name, "uk_name").IsUnique();

            entity.Property(e => e.IdOst)
                .ValueGeneratedNever()
                .HasColumnName("Id_Ost");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, 0L, 100000000L, null, null);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();

   
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
