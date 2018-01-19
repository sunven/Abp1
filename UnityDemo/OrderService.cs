using System.Threading;

namespace UnityDemo
{
    [UnityAop]
    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            var a = 0;
            for (var i = 0; i < 100000; i++)
                for (var j = 0; j < 10000; j++)
                    a = i - j;
            return a + "";
        }

        public string GetOrderDetail()
        {
            var a = 0;
            for (var i = 0; i < 100000; i++)
                for (var j = 0; j < 10000; j++)
                    a = i - j;
            return a + "";
        }
    }
}