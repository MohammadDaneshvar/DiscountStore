using Domain;
using System;
using System.Collections.Generic;

namespace Serviece.CartServices
{
    public interface ICartService
    {
       void Add(Item item);
       void Remove(Item item);
       decimal GetTotal();
        List<Item> GetItems();

    }
}
