namespace ATM
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Program
    {
        static void Main()
        {
            Withdraw("2222222222", "2222", 200);
        }

        static void Withdraw(string cardNumber, string PIN, decimal money)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=ATM; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlTransaction transaction = dbCon.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    SqlCommand cmd= new SqlCommand("SELECT * FROM CardAccounts WHERE CardNumber = '" + cardNumber + "'", dbCon);
                    cmd.Transaction = transaction;
                    SqlDataReader reader = cmd.ExecuteReader();
                    string card = string.Empty;
                    string pin = string.Empty;
                    decimal cash = 0;
                    while (reader.Read())
                    {
                        card = (string)reader["CardNumber"];
                        pin = (string)reader["CardPIN"];
                        cash = (decimal)reader["CardCash"];
                        Console.WriteLine("Account: {0} -> {1} -> {2}", card, pin, cash);
                    }

                    reader.Close();

                    SqlCommand cmdWithdraw = dbCon.CreateCommand();
                    cmdWithdraw.Transaction = transaction;

                    if (money <= cash && pin == PIN && cardNumber == card)
                    {
                        cmdWithdraw.CommandText = "UPDATE CardAccounts SET CardCash = CardCash - " + money +
                            "WHERE CardNumber = '" + cardNumber + "'";
                    }
                    else
                    {
                        transaction.Rollback();
                        Console.WriteLine("Invalid transaction!");
                    }

                    cmdWithdraw.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Transaction comitted.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Exception occured: {0}", e.Message);
                    transaction.Rollback();
                    Console.WriteLine("Transaction cancelled.");
                }
            }
        }
    }
}
