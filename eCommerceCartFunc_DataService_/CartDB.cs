using eCommerceCartFunc_Models_;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceCartFunc_DataService_
{
    public class CartDB : ICartDataService
    {
        private string connectString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=eCommerceApp_DB;Integrated Security=True;TrustServerCertificate=True";
        private SqlConnection sqlToConnect;
        public CartDB()
        {
            sqlToConnect = new SqlConnection(connectString);

        }

        public void AddItem(string productInCode, int productInQuanti)
        {
            Console.WriteLine("This is AddItem");
            var insertStmt = "INSERT INTO CartFunc_TB ([Product Code], [Product Quantity]) VALUES (@ProductCode, @ProductQuantity)";
            using var insertCmd = new SqlCommand(insertStmt, sqlToConnect);

            insertCmd.Parameters.AddWithValue("@ProductCode", productInCode);
            insertCmd.Parameters.AddWithValue("@ProductQuantity", productInQuanti);
            sqlToConnect.Open();
            insertCmd.ExecuteNonQuery();
            sqlToConnect.Close();

        }
        public List<Product> viewCart()
        {
            var products = new List<Product>();
            var selectStmt = "SELECT [Product Code], [Product Quantity] FROM CartFunc_TB";

            using var selectCmd = new SqlCommand(selectStmt, sqlToConnect);
            sqlToConnect.Open();

            using var toRead = selectCmd.ExecuteReader();
            while(toRead.Read())
            {
                var product = new Product
                {
                    ProductCode = toRead["Product Code"].ToString(),
                    ProductQuantity = Convert.ToInt32(toRead["Product Quantity"])
                };

                products.Add(product);
            }
            sqlToConnect.Close();
            return products;
        }
    }
}
