using System;

namespace Domain
{
    public class Item
    {
        public int Count { get; set; }
        public Product Product { get; set; }
        public Item(Product product,int count)
        {
            Product = product;
            Count = count;
        }
    }
}
