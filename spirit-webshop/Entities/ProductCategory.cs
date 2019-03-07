using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("product_category")]
    public partial class ProductCategory
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("fk_product")]
        public int FkProduct { get; set; }
        [Column("fk_category")]
        public int FkCategory { get; set; }

        [ForeignKey("FkCategory")]
        [InverseProperty("ProductCategory")]
        public virtual Category FkCategoryNavigation { get; set; }
        [ForeignKey("FkProduct")]
        [InverseProperty("ProductCategory")]
        public virtual Product FkProductNavigation { get; set; }
    }
}
