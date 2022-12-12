using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CalcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalcService))) 
            {
                host.Open();
                Console.WriteLine("Server was started");
                Console.WriteLine("Press <Enter> to close !!!");
                Console.ReadLine();
            }
        }
    }
}
