namespace ReadExcellFile
{
    using System;
    using System.Data.OleDb;

    class ReadExcellFile
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
                OleDbCommand cmd = new OleDbCommand("SELECT Id, Name, Score FROM [Sheet1$]", dbCon);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)(double)reader["Id"];
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];

                    Console.WriteLine("Id: {2}, Name: {0} -> {1}.", name, score, id);
                }
            }
        }
    }
}
