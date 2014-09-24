namespace NorthwindDbContext
{
    using System;

    class Program
    {
        static void Main()
        {
            //string customerId = DAO.InsertCustomerIntoNorthwind("GOSHO", "Gosho Birata");
            //Console.WriteLine("Inserted customer id = " + customerId);
            //Console.WriteLine("Gosho Birata was created as Customer.");

            //DAO.ModifyCompanyName(customerId, "Gosho Rakiata");
            //Console.WriteLine("Gosho Birata name changed to Gosho Rakiata");

            //DAO.DeleteCustomer("GOSHO");
            //Console.WriteLine("Deleted Gosho Rakiata Customer.");

            //var customers = DAO.FindAllCustomers("Canada", 1997);
            //foreach (var cust in customers)
            //{
            //    Console.WriteLine(cust.CompanyName + " --- " + cust.ContactName);
            //}

            //DAO.PrintAllCustomersByNativeSqlQuery("Canada", 1997);

            //var orders = DAO.SalesByRegionAndDates("RJ", new DateTime(1996, 1, 12), new DateTime(1998, 1, 1));
            //foreach (var order in orders)
            //{
            //    Console.WriteLine(order.Customer.CompanyName + " --- " + order.OrderDate.Value.ToString("dd-MMM-yyyy"));
            //}

            //DAO.CreateNestedContexts();

            //DAO.CreateOrder("WELLI", 3, DateTime.Today.AddDays(24), 2, "London");
        }
    }
}
