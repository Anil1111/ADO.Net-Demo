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
            AW_ProductRepo aw_pR = new AW_ProductRepo();
            List<AW_Product> products = aw_pR.GetAll();
            foreach (var prod in products)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(prod.ProductID);
                Console.WriteLine(prod.Name);
                Console.WriteLine(prod.Color);
                Console.WriteLine(prod.ListPrice);
                Console.WriteLine(prod.Size);
                Console.WriteLine(prod.SizeUnitMeasureCode);
                Console.WriteLine(prod.WeightUnitMeasureCode);
            }
        }
    }
}
