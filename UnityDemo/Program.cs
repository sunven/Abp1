﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Lifetime;
using Unity.Registration;

namespace UnityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = new UnityContainer();


            current.AddNewExtension<Interception>();
            current.RegisterType<IOrderService, OrderService>()
                .Configure<Interception>()
                .SetInterceptorFor<IOrderService>(new InterfaceInterceptor());
            var orderService = current.Resolve<IOrderService>();
            Console.WriteLine(orderService.GetOrder());
            Console.WriteLine(orderService.GetOrderDetail());
            Console.WriteLine(orderService.GetOrder());
            Console.WriteLine(orderService.GetOrderDetail());
            Console.WriteLine(orderService.GetOrder());
            Console.WriteLine(orderService.GetOrderDetail());
            //为什么第一次会慢？
            Console.ReadKey();
        }
    }
}