using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("order")]
    public partial class Order
    {
        public Order()
        {
            Position = new HashSet<Position>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("status")]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        [Column("pay_status")]
        [StringLength(10)]
        public string PayStatus { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [Column("street")]
        [StringLength(255)]
        public string Street { get; set; }
        [Required]
        [Column("zip")]
        [StringLength(10)]
        public string Zip { get; set; }
        [Required]
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [Column("place")]
        [StringLength(50)]
        public string Place { get; set; }
        [Column("fk_user")]
        public int FkUser { get; set; }

        [ForeignKey("FkUser")]
        [InverseProperty("Order")]
        public virtual User FkUserNavigation { get; set; }
        [InverseProperty("FkOrderNavigation")]
        public virtual ICollection<Position> Position { get; set; }
    }
}
