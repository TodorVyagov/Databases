namespace NorthwindDbContext
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class DAO
    {
        public static string InsertCustomerIntoNorthwind(string customerId, string companyName)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customerToInsert = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName
            };

            context.Customers.Add(customerToInsert);
            context.SaveChanges();
            return customerToInsert.CustomerID;
        }

        public static void ModifyCompanyName(string customerId, string newCompanyName)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customerToModify = context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            customerToModify.CompanyName = newCompanyName;
            context.SaveChanges();
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customerToDelete = context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
        }

        public static IEnumerable<Customer> FindAllCustomers(string country, int yearOfOrder)
        {
            // Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            NorthwindEntities context = new NorthwindEntities();
            var customers = context.Orders
                .Where(o => o.OrderDate.Value.Year == yearOfOrder && o.ShipCountry == country)
                .Select(o => o.Customer);
            return customers;
        }

        public static void PrintAllCustomersByNativeSqlQuery(string country, int yearOfOrder)
        {
            NorthwindEntities context = new NorthwindEntities();
            string query = @"SELECT c.ContactName
FROM Orders o
	JOIN Customers c
	 ON o.CustomerID = c.CustomerID
WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1}";

            object[] parameters = { yearOfOrder, country };
            var customers = context.Database.SqlQuery<string>(query, parameters);

            System.Console.WriteLine(customers.Count());
            foreach (var customer in customers)
            {
                System.Console.WriteLine(customer);
            }
        }

        public static IEnumerable<Order> SalesByRegionAndDates(string region, DateTime startYear, DateTime endYear)
        {
            // Write a method that finds all the sales by specified region and period (start / end dates).
            NorthwindEntities context = new NorthwindEntities();
            var orders = context.Orders
                .Where(o => o.ShipRegion == region && o.ShippedDate > startYear && o.ShippedDate < endYear);

            return orders;
        }

        public static void CreateNestedContexts()
        {
            NorthwindEntities dbOne = new NorthwindEntities();
            NorthwindEntities dbTwo = new NorthwindEntities();
            Customer customerOne = dbOne.Customers.Where(c => c.ContactName.Contains("no")).FirstOrDefault();
            Customer customerTwo = dbTwo.Customers.Where(c => c.ContactName.Contains("no")).FirstOrDefault();

            Console.WriteLine(customerOne.CompanyName);
            customerOne.CompanyName += "NEW1";
            Console.WriteLine(customerOne.CompanyName);
            dbOne.SaveChanges();

            Console.WriteLine(customerTwo.CompanyName);
            customerTwo.CompanyName += "NEW2";
            Console.WriteLine(customerTwo.CompanyName);
            dbTwo.SaveChanges();

            Customer customerEdited = dbOne.Customers.Where(c => c.ContactName.Contains("no")).FirstOrDefault();
            Console.WriteLine(customerEdited.CompanyName);
        }

        public static void CreateOrder(string customerId, int employeeId, DateTime orderDate, int shipVia, string shipCity)
        {
            NorthwindEntities context = new NorthwindEntities();
            Order newOrder = new Order();
            newOrder.CustomerID = customerId;
            newOrder.EmployeeID = employeeId;
            newOrder.OrderDate = orderDate;
            newOrder.ShipVia = shipVia;
            newOrder.ShipCity = shipCity;
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public static void GetIncome(int startYear, int endYear, string companyName)
        {
            NorthwindEntities context = new NorthwindEntities();

            using (context)
            {
                context.Database.ExecuteSqlCommand("CREATE PROCEDURE usp_GetIncomeByGivenCompany " +
                "@companyName nvarchar(60), @startDate date, @endDate date AS " +
                "SELECT s.CompanyName, SUM(od.UnitPrice * od.Quantity) AS Income " +
                "FROM Suppliers s " +
                "JOIN Products p " +
                "ON s.SupplierID = p.SupplierID " +
                "JOIN [Order Details] od " +
                "ON p.ProductID = od.ProductID " +
                "JOIN Orders o " +
                "ON od.OrderID = o.OrderID " +
                "where o.ShippedDate > @startDate AND o.ShippedDate < @endDate " +
                "AND s.CompanyName = @companyName " +
                "GROUP BY s.CompanyName");

                DateTime startDate = new DateTime(startYear, 1, 1);
                DateTime endDate = new DateTime(endYear, 1, 1);
                
                //var col = context.usp_GetIncomeByGivenCompany(companyName, startDate, endDate).First();
                //Console.WriteLine("Company name: {0} -> Income: {1}", colCompanyName, col.Income);
            }
        }

    }
}
