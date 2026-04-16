using eCommerceCartFunc_Models_;
using Microsoft.Data.SqlClient;
using System.Xml.Serialization;

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
        public bool isProductExist(string productInCode, int productInQuanti)
        {
            var products = new List<Product>();
            var isExistStmt = "SELECT COUNT(*) FROM CartFunc_TB " +
                              "WHERE [Product Code] = @ProductCode";
            using var isExistCmd = new SqlCommand(isExistStmt, sqlToConnect);
            isExistCmd.Parameters.AddWithValue("@ProductCode", productInCode);

            sqlToConnect.Open();
            int IsProductExist = Convert.ToInt32(isExistCmd.ExecuteScalar());
            sqlToConnect.Close();

            return IsProductExist>0;
        }

        public void updateQuantity (string productInCode, int productInQuanti)
        {
            var updateQuantiStmt = "UPDATE CartFunc_TB " +
                                       "SET [Product Quantity] = [Product Quantity] + @ProductQuantity " +
                                       "WHERE [Product Code] = @ProductCode";
            using var updateQuantiCmd = new SqlCommand(updateQuantiStmt, sqlToConnect);

            updateQuantiCmd.Parameters.AddWithValue("@ProductCode", productInCode);
            updateQuantiCmd.Parameters.AddWithValue("@ProductQuantity", productInQuanti);

            sqlToConnect.Open();
            updateQuantiCmd.ExecuteNonQuery();
            sqlToConnect.Close();
        }
        public bool isProductValid(string productInCode)
        {
            var products = new List<Product>();
            var isValidStmt = "SELECT [Product Code], [Product Name], [Product Price], [Category] " +
                               "FROM ProductsCatalog_TB " +
                               "WHERE [Product Code] = @ProductCode";
            using var isValidCmd = new SqlCommand(isValidStmt, sqlToConnect);
            isValidCmd.Parameters.AddWithValue("@ProductCode", productInCode);

            sqlToConnect.Open();
            using var toRead = isValidCmd.ExecuteReader();

            Product product = null;

            if (toRead.Read())
            {
                product = new Product
                {
                    ProductCode = toRead["Product Code"].ToString(),
                    ProductName = toRead["Product Name"]?.ToString() ?? string.Empty,
                    ProductPrice = Convert.ToDouble(toRead["Product Price"].ToString()),
                    Category = toRead["Category"]?.ToString() ?? string.Empty
                };
            }

            sqlToConnect.Close();
            return product != null;

        }

        public int? GetCartCapacity()
        {
            var checkStmt = "SELECT SUM([Product Quantity]) FROM CartFunc_TB";
            using var checkCmd = new SqlCommand(checkStmt, sqlToConnect);
            
            sqlToConnect.Open();
            object totalQuantity = checkCmd.ExecuteScalar();
            sqlToConnect.Close();

            if (totalQuantity == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(totalQuantity);
        }

        public void AddItem(string productInCode, int productInQuanti)
        {
            var insertStmt = "INSERT INTO CartFunc_TB ([Product Code], [Product Quantity]) " +
                             "VALUES (@ProductCode, @ProductQuantity)";
            using var insertCmd = new SqlCommand(insertStmt, sqlToConnect);

            insertCmd.Parameters.AddWithValue("@ProductCode", productInCode);
            insertCmd.Parameters.AddWithValue("@ProductQuantity", productInQuanti);

            sqlToConnect.Open();
            insertCmd.ExecuteNonQuery();
            sqlToConnect.Close();
        }

        public void RemoveItem(string productIncode)
        {
            var deleteStmt = "DELETE FROM CartFunc_TB " +
                             "WHERE [Product Code] = @ProductCode";
            using var deleteCmd = new SqlCommand(deleteStmt, sqlToConnect);
            deleteCmd.Parameters.AddWithValue("@ProductCode", productIncode);

            sqlToConnect.Open();
            deleteCmd.ExecuteNonQuery();
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
}}
