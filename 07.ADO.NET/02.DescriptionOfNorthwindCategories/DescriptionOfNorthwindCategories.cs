// Write a program that retrieves the name and description of all categories in the Northwind DB.
namespace DescriptionOfNorthwindCategories
{
    using System;
    using System.Data.SqlClient;

    class DescriptionOfNorthwindCategories
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string category = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("Category: {0} -> {1}.", category, description);
                }
            }
        }
    }
}
