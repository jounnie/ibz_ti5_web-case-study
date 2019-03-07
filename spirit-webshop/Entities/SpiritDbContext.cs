using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace spirit_webshop.Entities
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

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductPicture> ProductPicture { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.ParentCategoryNavigation)
                    .WithMany(p => p.InverseParentCategoryNavigation)
                    .HasForeignKey(d => d.ParentCategory)
                    .HasConstraintName("FK__category__parent__282DF8C2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PayStatus).IsUnicode(false);

                entity.Property(e => e.Place).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FkUser)
                    .HasConstraintName("FK__order__fk_user__367C1819");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.UserCurrency).IsUnicode(false);

                entity.HasOne(d => d.FkOrderNavigation)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.FkOrder)
                    .HasConstraintName("FK__position__fk_ord__395884C4");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.FkProduct)
                    .HasConstraintName("FK__position__fk_pro__3A4CA8FD");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PriceCurrency).IsUnicode(false);

                entity.Property(e => e.Visibility).IsUnicode(false);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.FkCategory)
                    .HasConstraintName("FK__product_c__fk_ca__2BFE89A6");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.FkProduct)
                    .HasConstraintName("FK__product_c__fk_pr__2B0A656D");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.Property(e => e.Base64).IsUnicode(false);

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.ProductPicture)
                    .HasForeignKey(d => d.FkProduct)
                    .HasConstraintName("FK__product_p__fk_pr__2EDAF651");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Place).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });
        }
    }
}
