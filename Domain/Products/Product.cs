using System;
using System.Collections.Generic;
using System.Text;

namespace Domain 
{
    public  class Product
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }
        public Product(int productId,string productTitle,ProductType productType,decimal price)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            ProductType = productType;
            Price = price;
        }
    }

    public enum ProductType
    {
        Vase,
        BigMug,
        Napkinspack
    }
}
