// Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
namespace NumberOfRowsInCategoryTable
{
    using System;
    using System.Data.SqlClient;

    class NumberOfRowsInCategoryTable
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int columnsCount = (int)cmd.ExecuteScalar();
                Console.WriteLine("Columns in Categories table are: " + columnsCount);
            }
        }
    }
}
