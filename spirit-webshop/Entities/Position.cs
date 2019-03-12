using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("position")]
    public partial class Position
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("fk_order")]
        public int FkOrder { get; set; }
        [Column("fk_product")]
        public int FkProduct { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("FkOrder")]
        [InverseProperty("Position")]
        public virtual Order FkOrderNavigation { get; set; }
        [ForeignKey("FkProduct")]
        [InverseProperty("Position")]
        public virtual Product FkProductNavigation { get; set; }
    }
}
