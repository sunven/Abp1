namespace OwinDemo.Service
{
    public interface IOrderService
    {
        string GetOrder();

        string GetOrderDetail(string s);
    }
}