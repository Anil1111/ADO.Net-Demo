using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODemoApp.Model;
using System.Data.SqlClient;
using ADODemoApp.Config;


namespace ADODemoApp.Repo
{
    public class AW_ProductRepo
    {
        public List<AW_Product> GetAll()
        {
            List<AW_Product> products = new List<AW_Product>();

            using (SqlConnection con = new SqlConnection(Settings.AdventureWorksConStr))
            {
                // Create a command

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT Top(5) ProductID,Name,Color,ListPrice," +
                                      "Size,SizeUnitMeasureCode,WeightUnitMeasureCode " +
                                      "FROM Production.Product " +
                                      "ORDER BY ProductModelID DESC";
                command.Connection = con;

                con.Open(); // must have open connection to query

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        products.Add(StoreOrderData(dr));
                    }
                }
            }
            return products;
        }

        private AW_Product StoreOrderData(SqlDataReader dr)
        {
            AW_Product product = new AW_Product();
            product.ProductID = (int)dr["ProductID"];
            product.Name = (string)dr["Name"];

            if (dr["Color"] != DBNull.Value)
                product.Color = (string)dr["Color"];

            product.ListPrice = (decimal)dr["ListPrice"];

            if (dr["Size"] != DBNull.Value)
                product.Size = (string)dr["Size"];

            if (dr["SizeUnitMeasureCode"] != DBNull.Value)
                product.SizeUnitMeasureCode = (string)dr["SizeUnitMeasureCode"];

            if (dr["WeightUnitMeasureCode"] != DBNull.Value)
                product.WeightUnitMeasureCode = (string)dr["WeightUnitMeasureCode"];

            return product;
        }
    }
}
