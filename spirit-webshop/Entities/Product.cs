using System;
using System.Collections.Generic;

namespace spirit_webshop.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Visibility { get; set; }
        public decimal? Price { get; set; }
        public string PriceCurrency { get; set; }
        public int? Stock { get; set; }
        public int? OrderQuantity { get; set; }
    }
}
