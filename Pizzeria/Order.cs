using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    internal class Order
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }

        public Order(Pizza pizza, int quantity)
        {
            Pizza = pizza;
            Quantity = quantity;
        }
    }
}
