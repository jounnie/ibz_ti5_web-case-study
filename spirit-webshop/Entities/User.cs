using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spirit_webshop.Entities
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [Column("forename")]
        [StringLength(255)]
        public string Forename { get; set; }
        [Required]
        [Column("lastname")]
        [StringLength(255)]
        public string Lastname { get; set; }
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
        [Required]
        [Column("mail")]
        [StringLength(50)]
        public string Mail { get; set; }
        [Required]
        [Column("password")]
        [StringLength(1000)]
        public string Password { get; set; }
        [Required]
        [Column("type")]
        [StringLength(10)]
        public string Type { get; set; }

        [InverseProperty("FkUserNavigation")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
