namespace TransparentProxyDemo
{
    public class OrderService : IOrderService
    {
        public string GetOrder()
        {
            return "GetOrder123";
        }

        public string GetOrderDetail()
        {
            return "GetOrderDetail123";
        }
    }
}