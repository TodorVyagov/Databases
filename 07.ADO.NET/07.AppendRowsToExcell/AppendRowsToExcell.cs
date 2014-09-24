namespace AppendRowsToExcell
{
    using System;
    using System.Data.OleDb;

    class AppendRowsToExcell
    {
        static void Main()
        {
            // if not working try with commented string
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=..\..\SampleSheet.xlsx; Persist Security Info=False; " +
            "Extended Properties=Excel 12.0";
            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //@"Data Source=..\..\SampleSheet.xls; Persist Security Info=False; " +
            //"Extended Properties=Excel 8.0";

            OleDbConnection dbCon = new OleDbConnection(connectionString);
            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [Sheet1$](Id, Name, Score)" +
                    "VALUES(@id, @name, @score)", dbCon);
                cmd.Parameters.AddWithValue("@id", 123456);
                cmd.Parameters.AddWithValue("@name", "Ivanov");
                cmd.Parameters.AddWithValue("@Score", 99.99);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
