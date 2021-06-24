using Domain;
using Servieces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Serviece.CartServices
{
    public class CartService : ICartService
    {
        IEnumerable<IDiscountable> discountableStrategies;
        List<Item> items=new List<Item>();
        public CartService()
        {
            var interfaceType = typeof(IDiscountable);
            discountableStrategies = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(x =>(IDiscountable) Activator.CreateInstance(x));

            
        }
        public void Add(Item item)
        {
            var isExists = items.Any(x => x.Product.ProductType ==item.Product.ProductType);
            if (isExists)
                items.FirstOrDefault(x => x.Product.ProductType == item.Product.ProductType).Count += item.Count ;
            else
                items.Add(item);
        }

        public List<Item> GetItems()
        {
            return items;        }

        public decimal GetTotal()
         => items.Aggregate(0M, (sum, item) =>
         {
             discountableStrategies.ToList().ForEach(d =>
             {
                 if (d.IsSatisfied(item))
                 {
                     sum = sum + d.Calculate(item);
                 }
             });
             return sum;
         });

        public void Remove(Item item)
        {
            var isExist = items.Any(x => x.Product.ProductType == item.Product.ProductType);
            if (isExist)
            {
                var product = items.FirstOrDefault(x => x.Product.ProductType == item.Product.ProductType);
                if (product.Count <= item.Count)
                    items.Remove(product);
                else
                    product.Count -= item.Count;


            }
        }
    }
}
