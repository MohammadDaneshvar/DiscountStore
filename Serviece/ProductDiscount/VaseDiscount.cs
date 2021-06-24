using Domain;
using Serviece.CartServices;
using System.Collections.Generic;
using System.Linq;

namespace Servieces
{
    public class VaseDiscount : IDiscountable
    {
        public List<(int min, int max, decimal percent)> countableDiscount = new List<(int, int, decimal)> {
           (1,int.MaxValue,1M)
        };
        public decimal Calculate(Item item)
        {
            return item.Product.Price * countableDiscount
                .FirstOrDefault(c => c.min <= item.Count && c.max > item.Count).percent; 
        }

        public bool IsSatisfied(Item item)
        => item.Product.ProductType == ProductType.Vase;

    }
}
