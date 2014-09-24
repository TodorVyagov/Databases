// Write a program that reads a string from the console and finds all products that contain this string. 
namespace SearchInProducts
{
    using System;
    using System.Data.SqlClient;

    class SearchInProducts
    {
        static void Main()
        {
            Console.WriteLine("Enter substring to search in Products from Northwind database.");
            string phraseToSearch = Console.ReadLine();

            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "SELECT ProductName FROM Products WHERE ProductName LIKE '%{0}%'", phraseToSearch), dbCon);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Found products:");

                while (reader.Read())
                {
                    string foundWord = (string)reader["ProductName"];
                    Console.WriteLine(foundWord);
                }
            }
        }
    }
}
