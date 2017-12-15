using System.Threading;

namespace UnityDemo
{
    [UnityAop]
    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            return "GetOrder123";
        }

        public string GetOrderDetail()
        {
            //Thread.Sleep(1000);
            return "GetOrderDetail123";
        }
    }
}