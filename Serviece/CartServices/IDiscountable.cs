using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serviece.CartServices
{
    public interface IDiscountable
    {
        bool IsSatisfied(Item product);
        decimal Calculate(Item product);
    }
}
