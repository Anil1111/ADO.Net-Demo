using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODemoApp.Config;
using ADODemoApp.Model;

namespace ADODemoApp.Repo
{
    public class AW_ProductModelRepo
    {
        public void CreateGetClothingProcedureIfNull()
        {
            using (SqlConnection con = new SqlConnection(Settings.AdventureWorksConStr))
            {
                SqlCommand checkIfProcExists = new SqlCommand();
                checkIfProcExists.CommandText = "IF (OBJECT_ID('GetProductsByGender') IS NOT NULL) " +
                                                "DROP PROCEDURE GetProductsByGender " +
                                                "";
                checkIfProcExists.Connection = con;

                con.Open();

                using (SqlDataReader dr = checkIfProcExists.ExecuteReader())
                {
                }

                con.Close();

                SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE PROCEDURE GetProductsByGender (@strGender varchar(5)) " +
                                      "AS " +
                                      "SELECT ProductModelID, Name " +
                                      "FROM Production.ProductModel " +
                                      "WHERE Name LIKE @strGender";
                command.Connection = con;

                con.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                }
            }
        }

        public List<AW_ProductModel> GetProductsByGender(string gender)
        {
            List<AW_ProductModel> products = new List<AW_ProductModel>();

            using (SqlConnection con = new SqlConnection(Settings.AdventureWorksConStr))
            {
                SqlCommand command = new SqlCommand
                {
                    CommandText = "GetProductsByGender",
                    CommandType = CommandType.StoredProcedure
                };

                command.Connection = con;
                command.Parameters.AddWithValue("@strGender", gender);

                con.Open();

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

        private AW_ProductModel StoreOrderData(SqlDataReader dr)
        {
            AW_ProductModel productM = new AW_ProductModel();
            productM.ProductModelID = (int)dr["ProductModelID"];
            productM.Name = (string)dr["Name"];

            return productM;
        }
    }
}
