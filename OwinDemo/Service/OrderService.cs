namespace OwinDemo.Service
{
    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            return "GetOrder123";
        }

        public string GetOrderDetail(string s)
        {
            return "GetOrderDetail" + s;
        }
    }
}