using System;
using System.Threading;

namespace UnityDemo
{
    [UnityAop]
    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            Thread.Sleep(new Random().Next(500, 1000));
            return "GetOrder";
        }

        public string GetOrderDetail()
        {
            var i = Convert.ToInt32("a");
            return i + "GetOrder";
        }
    }
}