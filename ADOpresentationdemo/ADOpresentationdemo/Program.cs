using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODemoApp.Repo;
using ADODemoApp.Model;

namespace ADOpresentationdemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintOrders();
            Console.ReadLine();
        }

        private static void PrintOrders()
        {
            OrderRepo oR = new OrderRepo();
            List<Order> Orders = oR.GetAll();
            foreach (var or in Orders)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(or.OrderID);
                Console.WriteLine(or.OrderDate);
                Console.WriteLine(or.RequiredDate);
                Console.WriteLine(or.ShippedDate);
                Console.WriteLine(or.ShipName);
                Console.WriteLine(or.ShipAddress);
                Console.WriteLine(or.ShipCity);
                Console.WriteLine(or.ShipRegion);
                Console.WriteLine(or.ShipPostalCode);
                Console.WriteLine(or.ShipCountry);
            }
        }
    }
}
