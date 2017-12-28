namespace OwinDemo
{
    public interface IOrderService
    {
        string GetOrder();

        string GetOrderDetail(string s);
    }
}