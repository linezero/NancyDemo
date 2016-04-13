using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:9000";
            using (var host = new NancyHost(new Uri(url)))
            {
                host.Start();
                Console.WriteLine("Start "+url);
                Console.ReadLine();
            }
        }
    }
}
