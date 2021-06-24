using Domain;
using Serviece.CartServices;
using System.Collections.Generic;
using System.Linq;

namespace Servieces
{

    public class BigMugDiscount : IDiscountable
    {
        public List<(int min, int max, decimal percent)> countableDiscount = new List<(int, int, decimal)> {
           (1,1,1M),
           (2,int.MaxValue,0.75M)
        };
        public decimal Calculate(Item item)
        {
            return item.Count* item.Product.Price * countableDiscount
                .FirstOrDefault(c => c.min <= item.Count && c.max > item.Count).percent; //countableDiscount[item.Count]();
        }

        public bool IsSatisfied(Item item)
        => item.Product.ProductType == ProductType.BigMug;
    }
}
