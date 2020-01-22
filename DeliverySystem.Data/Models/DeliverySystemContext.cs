using System;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Data.Models
{
    public partial class DeliverySystemContext : DbContext
    {
        public DeliverySystemContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<TestCategories> TestCategories { get; set; }
        public virtual DbSet<TestOrderProducts> TestOrderProducts { get; set; }
        public virtual DbSet<TestOrders> TestOrders { get; set; }
        public virtual DbSet<TestProductCategories> TestProductCategories { get; set; }
        public virtual DbSet<TestProducts> TestProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestOrderProducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<TestOrders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestProductCategories>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });
            });

            modelBuilder.Entity<TestProducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Query<SPShipmentsGetByAddressAndCategoryId>();
            modelBuilder.Query<SPShipmentsGetAll>();
        }
    }
}
