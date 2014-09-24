namespace MyStudentSystem.ConsoleApplication
{
    using System;
    using System.Linq;

    using MyStudentSystem.Data;
    using MyStudentSystem.Data.Migrations;
    using MyStudentSystem.Model;
    using System.Data.Entity;

    public class MyStudentSystemConsoleApplication
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyStudentSystemDbContext, Configuration>());
            var db = new MyStudentSystemDbContext();

            var student = new Student
            {
                FirstName = "Pesho2",
                LastName = "Peshov2",
                Number = 222222
            };

            student.Courses.Add(new Course
            {
                Name = "Databases"

            });

            db.Students.Add(student);
            db.SaveChanges();

            var savedStudent = db.Courses.FirstOrDefault();
            Console.WriteLine(savedStudent.Id + " " + savedStudent.Name);
        }
    }
}
