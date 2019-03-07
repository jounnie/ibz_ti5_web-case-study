using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("product")]
    public partial class Product
    {
        public Product()
        {
            Position = new HashSet<Position>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductPicture = new HashSet<ProductPicture>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(5000)]
        public string Description { get; set; }
        [Required]
        [Column("visibility")]
        [StringLength(10)]
        public string Visibility { get; set; }
        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [Column("price_currency")]
        [StringLength(3)]
        public string PriceCurrency { get; set; }
        [Column("stock")]
        public int? Stock { get; set; }
        [Column("order_quantity")]
        public int? OrderQuantity { get; set; }

        [InverseProperty("FkProductNavigation")]
        public virtual ICollection<Position> Position { get; set; }
        [InverseProperty("FkProductNavigation")]
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        [InverseProperty("FkProductNavigation")]
        public virtual ICollection<ProductPicture> ProductPicture { get; set; }
    }
}
