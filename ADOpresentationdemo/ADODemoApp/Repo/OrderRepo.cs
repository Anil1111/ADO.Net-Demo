using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODemoApp.Model;
using System.Data.SqlClient;
using ADODemoApp.Config;


namespace ADODemoApp.Repo
{
    public class OrderRepo
    {
        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection con = new SqlConnection(Settings.ConnectionString))
            {
                // Create a command
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT OrderID, OrderDate, RequiredDate, ShippedDate, ShipName, ShipAddress, " +
                                      "ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders";
                command.Connection = con;

                con.Open(); // must have open connection to query

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        orders.Add(StoreOrderData(dr));
                    }
                }
            }
            return orders;
        }

        private Order StoreOrderData(SqlDataReader dr)
        {
            Order order = new Order();
            order.OrderID = (int)dr["OrderID"];
            order.OrderDate = (DateTime)dr["OrderDate"];
            order.RequiredDate = (DateTime)dr["RequiredDate"];

            if (dr["ShippedDate"] != DBNull.Value)
            {
                order.ShippedDate = (DateTime)dr["ShippedDate"];
            }

            order.ShipName = (string)dr["ShipName"];
            order.ShipAddress = (string)dr["ShipAddress"];
            order.ShipCity = (string)dr["ShipCity"];

            if (dr["ShipRegion"] != DBNull.Value)
            {
                order.ShipRegion = (string)dr["ShipRegion"];
            }

            if (dr["ShipPostalCode"] != DBNull.Value)
            {
                order.ShipPostalCode = (string)dr["ShipPostalCode"];
            }

            order.ShipCountry = (string)dr["ShipCountry"];

            return order;
        }
    }
}
