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

            OrderLine apple = new OrderLine(1, 2.5m, 0.0f);
            Order order = new Order(ImmutableList.Create(apple));

            OrderLine discountedApple = apple.WithDiscount(0.1f);
            Order discountedOrder = order.ReplaceLine(apple, discountedApple);

            //这种设计的好处是，它尽可能避免了不必要的对象创建。例如，当折扣的值等于 0.0 f，即时没有折扣,，discountedApple 和 discountedOrder 引用现有实例的苹果和订单。
            //这是因为:
            //1.apple.WithDiscount() 将返回苹果的现有实例，因为新的折扣是相同折扣属性的当前值。
            //2.order.ReplaceLine() 如果两个参数都相同，将返回现有实例。
            //我们不变的集合其他操作遵循这种最大化重用。例如，将订单行添加到 1000 的订单行的订单与 1,001 订单行不会创建整个的新列表。相反，它将重用现有列表一大块。这是可能的因为列表内部结构是为一棵树，允许共享不同实例的节点。


            var immutableList1 = ImmutableList.Create("a", "b", "c");
            var builder = immutableList1.ToBuilder();
            builder.Add("d");
            foreach (var item in immutableList1)
            {
                Console.WriteLine(item);
            }
            //immutableList1并没有变
            Console.WriteLine("------");
            immutableList1 = builder.ToImmutable();
            //immutableList1变了
            foreach (var item in immutableList1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
