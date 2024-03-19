using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using e_Parcel.Models;

namespace e_Parcel.DataAccess;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Mail> Mails { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    public virtual DbSet<ShoppingSession> ShoppingSessions { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserPayment> UserPayments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=defaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_Products");

            entity.HasOne(d => d.Session).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_ShoppingSession");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(false);
        });

        modelBuilder.Entity<Mail>(entity =>
        {
            entity.Property(e => e.Code).HasDefaultValue("");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_UserLogin");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_OrderDetails");

            entity.HasOne(d => d.Product).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetails_OrderDetails");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ImageUrl).HasDefaultValue("");

            entity.HasOne(d => d.Discount).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Discount");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductInventory");
        });

        modelBuilder.Entity<ShoppingSession>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.ShoppingSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingSession_UserLogin");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.UserAddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAddress_UserLogin");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.Property(e => e.IsDisabled).HasDefaultValue(false);
        });

        modelBuilder.Entity<UserPayment>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.UserPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPayment_UserLogin");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
