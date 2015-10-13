using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADODemoApp.Config
{
    public class Settings
    {
        //public static string NorthwindConStr = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        public static string AdventureWorksConStr = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
    }
}
