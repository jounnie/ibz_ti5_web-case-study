using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("category")]
    public partial class Category
    {
        public Category()
        {
            InverseParentCategoryNavigation = new HashSet<Category>();
            ProductCategory = new HashSet<ProductCategory>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("parent_category")]
        public int? ParentCategory { get; set; }

        [ForeignKey("ParentCategory")]
        [InverseProperty("InverseParentCategoryNavigation")]
        public virtual Category ParentCategoryNavigation { get; set; }
        [InverseProperty("ParentCategoryNavigation")]
        public virtual ICollection<Category> InverseParentCategoryNavigation { get; set; }
        [InverseProperty("FkCategoryNavigation")]
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
