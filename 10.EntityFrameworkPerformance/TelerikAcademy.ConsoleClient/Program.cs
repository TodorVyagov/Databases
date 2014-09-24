/*Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and
 * later print their name, department and town. Try the both variants: with and without .Include(…).
 * Compare the number of executed SQL statements and the performance.
Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), 
 * then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks
 * whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.
*/
namespace TestingEFQueries.ConsoleClient
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademy.Model;

    class Program
    {
        static void Main()
        {
            var context = new TelerikAcademyEntities();

            // Task 1
            foreach (var employee in context.Employees)
            {
                // we make this way unneccessary queries to the server
                Console.WriteLine("Employee: {0}; {1}; {2}", employee.FirstName + " " + employee.LastName,
                    employee.Department.Name, employee.Address.Town.Name);
            }

            foreach (var employee in context.Employees.Include("Department").Include("Address"))
            {
                // only one query
                Console.WriteLine("Employee: {0}; {1}; {2}", employee.FirstName + " " + employee.LastName,
                   employee.Department.Name, employee.Address.Town.Name);
            }

            // Task 2
            var employeesFromSofia = context.Employees.ToList()
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    City = e.Address.Town.Name
                }).ToList()
                .Where(e => e.City == "Sofia").ToList();
            foreach (var employee in employeesFromSofia)
            {
                Console.WriteLine(employee.Name + " " + employee.City);
            }

            var employeesFromSofiaOneQuery = context.Employees
                .Where(e => e.Address.Town.Name == "Sofia");
            foreach (var employee in employeesFromSofiaOneQuery)
            {
                Console.WriteLine(employee.FirstName + " " + employee.Address.Town.Name);
            }
        }
    }
}
