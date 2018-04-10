using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrderLineImmutable apple = new OrderLineImmutable(quantity: 1, unitPrice: 2.5m, discount: 0.0f);

            //OrderLineImmutable discountedAppled = apple.WithDiscount(.3f);


            //


            OrderLine apple = new OrderLine(quantity: 1, unitPrice: 2.5m, discount: 0.0f);
            Order order = new Order(ImmutableList.Create(apple));

            OrderLine discountedApple = apple.WithDiscount(0.1f);
            Order discountedOrder = order.ReplaceLine(apple, discountedApple);
        }
    }
}
