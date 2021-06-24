using Domain;
using System.Collections.Generic;

namespace UnitTest.DataSamples
{
    public static class DataSample
    {
        public static List<Product> Products = new List<Product>();
        public static List<Item> Items = new List<Item>();
        static DataSample()
        {
            Products = new List<Product>
            {
                new Product(3,"Vase",ProductType.Vase,1.2M),
                new Product(1,"BigMug",ProductType.BigMug,1M),
                new Product(2,"Napkinspack",ProductType.Napkinspack,0.45M),
            };
            Items = new List<Item>
            {
                new Item(Products[0],1),
                new Item(Products[1],3),
                new Item(Products[2],4),
            };
        }

        public static Item Get_Item_With_2_Number_Of_NapkinsPack()
        {
            return new Item(new Product(1, "Napkins pack", ProductType.Napkinspack, 0.45M), 2);
        }

        public static Item Get_Item_With_2_Number_Of_BigMug()
        {
            return new Item(new Product(1, "BigMug", ProductType.BigMug, 1M), 2);
        }
        public static Item Get_Item_With_1_Number_Of_Vase()
        {
            return new Item(new Product(1, "Vase", ProductType.Vase, 1.2M),1 );
        }
        public static List<Item> Get_Items_With_3Number_Of_Each_Product()
        {
            Items = new List<Item>
            {
                new Item(Products[0],3),
                new Item(Products[1],3),
                new Item(Products[2],3),
            };
            return Items;
        }
    }
}
