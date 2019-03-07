using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("product_picture")]
    public partial class ProductPicture
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("fk_product")]
        public int FkProduct { get; set; }
        [Required]
        [Column("base64")]
        public string Base64 { get; set; }

        [ForeignKey("FkProduct")]
        [InverseProperty("ProductPicture")]
        public virtual Product FkProductNavigation { get; set; }
    }
}
