using Domain;
using Servieces;
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
            discountableStrategies = new List<IDiscountable> { new VaseDiscount(),new NapkinspackDiscount(),new BigMugDiscount() };
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
         => items.Aggregate(0M, (acc, i) =>
         {
             discountableStrategies.ToList().ForEach(d =>
             {
                 if (d.IsSatisfied(i))
                 {
                     acc = acc + d.Calculate(i);
                 }
             });
             return acc;
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
