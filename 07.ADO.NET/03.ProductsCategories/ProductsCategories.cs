// Write a program that retrieves from the Northwind database all product categories and
// the names of the products in each category. Can you do this with a single SQL query (with table join)?
namespace ProductsCategories
{
    using System;
    using System.Data.SqlClient;
    class ProductsCategories
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID", dbCon);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string category = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];

                    Console.WriteLine(category + " -> " + product);
                }
            }
        }
    }
}
