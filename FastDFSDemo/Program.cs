using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FastDFS.Client;

namespace FastDFSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new FileStream(@"D:\1.jpg", FileMode.Open);

            ConnectionManager.Initialize(new List<IPEndPoint>{new IPEndPoint(IPAddress.Parse("172.16.2.154"), 22122) });
            var g = FastDFSClient.GetStorageNode("group2");
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            //FastDFSClient.UploadFile(g, b, "jpg");
            Console.ReadKey();
        }
    }
}
