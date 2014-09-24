// Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
namespace AddProductWithParameterizedQuery
{
    using System;
    using System.Data.SqlClient;

    class AddProductWithParameterizedQuery
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                int addedProductIdNumber = InsertProduct("VAFLA", 3, 2, "12 na cenata na 1", 1.23M, 500, 25, 2, true, dbCon);
                Console.WriteLine("Added product ID is: " + addedProductIdNumber);
            }
        }

        public static int InsertProduct(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
            int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued, SqlConnection dbCon)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit,  " + "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@name, @SupplierID, @CategoryID, " + "@QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", dbCon);
            cmd.Parameters.AddWithValue("@name", productName);
            cmd.Parameters.AddWithValue("@SupplierID", supplierID);
            cmd.Parameters.AddWithValue("@CategoryID", categoryID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", discontinued);
            cmd.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedProductId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedProductId;
        }

    }
}
