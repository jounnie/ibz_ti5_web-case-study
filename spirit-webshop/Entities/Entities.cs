using System.Collections.Generic;

namespace spirit_webshop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Visibility { get; set; }
        public decimal? Price { get; set; }
        public string PriceCurrency { get; set; }
        public int? Stock { get; set; }
        public int? OrderQuantity { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class ProductCategory
    {
        public int FkProduct { get; set; }
        public Product Product { get; set; }
        public int FkCategory { get; set; }
        public Category Category { get; set; }
    }
}