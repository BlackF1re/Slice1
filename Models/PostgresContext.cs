using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Slice1.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    // public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1488");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        // modelBuilder.Entity<Product>(entity =>
        // {
        //     entity.HasKey(e => e.Id).HasName("product_pk");
        //
        //     entity.ToTable("products");
        //
        //     entity.Property(e => e.Id)
        //         .UseIdentityAlwaysColumn()
        //         .HasColumnName("id");
        //     entity.Property(e => e.Brand)
        //         .HasMaxLength(30)
        //         .HasColumnName("brand");
        //     entity.Property(e => e.Color)
        //         .HasMaxLength(30)
        //         .HasColumnName("color");
        //     entity.Property(e => e.Country)
        //         .HasMaxLength(30)
        //         .HasColumnName("country");
        //     entity.Property(e => e.Model)
        //         .HasMaxLength(30)
        //         .HasColumnName("model");
        //     entity.Property(e => e.Price).HasColumnName("price");
        //     entity.Property(e => e.Quantity).HasColumnName("quantity");
        // });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pk");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Bitrhday)
                .HasMaxLength(10)
                .HasColumnName("bitrhday");
            entity.Property(e => e.Fio)
                .HasMaxLength(30)
                .HasColumnName("fio");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
