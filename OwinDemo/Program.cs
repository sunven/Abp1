using Microsoft.Owin.Hosting;
using System;

namespace OwinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:8080/";
            var startOpts = new StartOptions(url);
            using (WebApp.Start<Startup>(startOpts))
            {
                Console.WriteLine("Server run at " + url + " , press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
