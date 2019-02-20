using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace web_shop_server.Entities
{
    public partial class SpiritDbContext : DbContext
    {
        public SpiritDbContext()
        {
        }

        public SpiritDbContext(DbContextOptions<SpiritDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ti5-spirit-db.database.windows.net,1433;Initial Catalog=ti5-spirit-db;Persist Security Info=False;User ID=spirit-admin;Password=w6uJDSb4Z%8%M9$cy@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PriceCurrency)
                    .HasColumnName("price_currency")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasColumnName("visibility")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
