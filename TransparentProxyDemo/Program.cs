using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparentProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ClientProxy(typeof(IOrderService));
            var tp = proxy.GetTransparentProxy();
            var serviceProxy = tp as IOrderService;
            Console.WriteLine(serviceProxy.GetOrder());//GetOrderabc
            Console.WriteLine(serviceProxy.GetOrderDetail());//GetOrderDetailabc
            Console.ReadKey();
        }
    }
}
