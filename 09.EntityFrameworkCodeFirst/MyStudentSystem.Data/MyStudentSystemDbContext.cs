namespace MyStudentSystem.Data
{
    using System.Data.Entity;

    using MyStudentSystem.Model;

    public class MyStudentSystemDbContext : DbContext
    {
        public MyStudentSystemDbContext()
            : base("MyStudentSystem")
        {
        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
